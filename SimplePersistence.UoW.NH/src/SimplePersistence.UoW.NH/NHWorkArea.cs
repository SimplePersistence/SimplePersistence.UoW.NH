namespace SimplePersistence.UoW.NH
{
    using System;
    using NHibernate;

    /// <summary>
    /// Represents a work area that can be used for aggregating
    /// UoW properties, specialized for the NHibernate
    /// </summary>
    public abstract class NHWorkArea : INHWorkArea
    {
        #region Implementation of INHWorkArea

        /// <summary>
        /// The database session object
        /// </summary>
        public ISession Session { get; }

        #endregion

        /// <summary>
        /// Creates a new work area that will use the given database session
        /// </summary>
        /// <param name="session">The database session</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected NHWorkArea(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            Session = session;
        }
    }
}
