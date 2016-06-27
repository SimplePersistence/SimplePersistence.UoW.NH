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
    using NHibernate;

    /// <summary>
    /// Represents a database session. Mainly used to wrap an <see cref="ISession"/> 
    /// when using multiple database sources
    /// </summary>
    public abstract class DatabaseSession : IDatabaseSession, IDisposable
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="session">The database session object</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected DatabaseSession(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));

            Session = session;
        }

        /// <summary>
        /// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        /// </summary>
        ~DatabaseSession()
        {
            Dispose(false);
        }

        #region Implementation of IDatabaseSession

        /// <summary>
        /// The database session object
        /// </summary>
        public ISession Session { get; private set; }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            Session.Dispose();
            Session = null;
        }

        #endregion
    }
}