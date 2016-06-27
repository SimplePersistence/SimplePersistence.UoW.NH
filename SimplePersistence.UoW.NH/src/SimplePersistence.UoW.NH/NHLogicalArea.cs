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
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// Represents an area used to aggregate Unit of Work logic, 
    /// like data transformations or procedures, specialized for NHibernate.
    /// </summary>
    public abstract class NHLogicalArea : INHLogicalArea
    {
        #region Implementation of INHLogicalArea

        /// <summary>
        /// The database session object
        /// </summary>
        public ISession Session { get; }

        /// <summary>
        /// Prepares an <see cref="IQueryable{T}"/> for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <returns>The <see cref="IQueryable{T}"/> for the specified entity type.</returns>
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Session.Query<TEntity>();
        }

        #endregion

        /// <summary>
        /// Creates a new logical area that will use the given database session
        /// </summary>
        /// <param name="session">The database session object</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected NHLogicalArea(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));

            Session = session;
        }

        /// <summary>
        /// Creates a new logical area that will use the given database session wrapper
        /// </summary>
        /// <param name="databaseSession">The database session wrapper</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected NHLogicalArea(IDatabaseSession databaseSession)
        {
            if (databaseSession == null)
                throw new ArgumentNullException(nameof(databaseSession));

            Session = databaseSession.Session;
        }
    }
}