#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 SimplePersistence
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
namespace SimplePersistence.UoW.NH
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using NHibernate;

    /// <summary>
    /// An implementation compatible with NHibernate for the Unit of Work pattern.
    /// Underline, it also uses work scopes (see: <see cref="ScopeEnabledUnitOfWork"/>).
    /// </summary>
    public abstract class NHUnitOfWork : ScopeEnabledUnitOfWork, INHUnitOfWork, IDisposable
    {
        private volatile ISession _session;
        private volatile ITransaction _transaction;

        #region Implementation of INHUnitOfWork

        /// <summary>
        /// The database session object
        /// </summary>
        public ISession Session => _session;

        #endregion

        /// <summary>
        /// Creates a new unit of work that will extract the current <see cref="ISession"/> using <see cref="ISessionFactory.OpenSession()"/>
        /// </summary>
        /// <param name="sessionFactory">The session factory</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected NHUnitOfWork(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null) throw new ArgumentNullException(nameof(sessionFactory));
            _session = sessionFactory.OpenSession();
        }

        /// <summary>
        /// Creates a new unit of work that will use the given <see cref="ISession"/>
        /// </summary>
        /// <param name="session">The database session</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected NHUnitOfWork(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            _session = session;
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~NHUnitOfWork()
        {
            Dispose(false);
        }

        #region Overrides of ScopeEnabledUnitOfWork

        /// <summary>
        /// Invoked once for any given scope, it should prepare the
        ///             current instance for any subsequent work
        /// </summary>
        protected override void OnBegin()
        {
            _transaction = _session.BeginTransaction();
        }

        /// <summary>
        /// Invoked once for any given scope, it should prepare the
        ///             current instance for any subsequent work
        /// </summary>
        /// <param name="ct">The cancellation token</param>
        /// <returns>
        /// The task for this operation
        /// </returns>
#if NET40
        protected override Task OnBeginAsync(CancellationToken ct)
        {
            return Task.Factory.StartNew(OnBegin, ct);
        }
#else
        protected override async Task OnBeginAsync(CancellationToken ct)
        {
            await Task.Run(() => OnBegin(), ct);
        }
#endif

        /// <summary>
        /// Invoked once for any given scope, it should commit any work
        ///             made by this instance
        /// </summary>
        /// <exception cref="T:SimplePersistence.UoW.Exceptions.CommitException">
        /// Thrown when the work failed to commit
        /// </exception>
        /// <exception cref="T:SimplePersistence.UoW.Exceptions.ConcurrencyException">
        /// Thrown when the work can't be committed due to concurrency conflicts
        /// </exception>
        protected override void OnCommit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (StaleObjectStateException e)
            {
                throw new ConcurrencyException(e);
            }
        }

        /// <summary>
        /// Invoked once for any given scope, it should commit any work
        ///             made by this instance
        /// </summary>
        /// <param name="ct">The cancellation token</param>
        /// <returns>
        /// The task for this operation
        /// </returns>
        /// <exception cref="T:SimplePersistence.UoW.Exceptions.CommitException">
        /// Thrown when the work failed to commit
        /// </exception>
        /// <exception cref="T:SimplePersistence.UoW.Exceptions.ConcurrencyException">
        /// Thrown when the work can't be committed due to concurrency conflicts
        /// </exception>
#if NET40
        protected override Task OnCommitAsync(CancellationToken ct)
        {
            return Task.Factory.StartNew(OnCommit, ct);
        }
#else
        protected override async Task OnCommitAsync(CancellationToken ct)
        {
            await Task.Run(() => OnCommit(), ct);
        }
#endif

        /// <summary>
        /// Prepares a given <see cref="T:System.Linq.IQueryable`1"/> for asynchronous work.
        /// </summary>
        /// <typeparam name="T">The query item type</typeparam><param name="queryable">The query to wrap</param>
        /// <returns>
        /// An <see cref="T:SimplePersistence.UoW.IAsyncQueryable`1"/> instance, wrapping the given query
        /// </returns>
        public override IAsyncQueryable<T> PrepareAsyncQueryable<T>(IQueryable<T> queryable)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            return new NHAsyncQueryable<T>(queryable);
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposing) return;

            _session.Dispose();
            _session = null;
            _transaction = null;
        }

        #endregion
    }
}
