namespace SimplePersistence.UoW.NH
{
    using NHibernate;

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

        #endregion

        /// <summary>
        /// Creates a new logical area that will use the given database session
        /// </summary>
        /// <param name="session"></param>
        protected NHLogicalArea(ISession session)
        {
            Session = session;
        }
    }
}