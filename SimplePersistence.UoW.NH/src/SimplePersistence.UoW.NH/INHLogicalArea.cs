namespace SimplePersistence.UoW.NH
{
    using NHibernate;

    /// <summary>
    /// Represents an area used to aggregate Unit of Work logic, 
    /// like data transformations or procedures, specialized for NHibernate.
    /// </summary>
    public interface INHLogicalArea : ILogicalArea
    {
        /// <summary>
        /// The database session object
        /// </summary>
        ISession Session { get; }
    }
}