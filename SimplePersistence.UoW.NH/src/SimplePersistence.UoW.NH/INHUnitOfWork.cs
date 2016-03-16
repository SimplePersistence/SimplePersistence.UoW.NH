namespace SimplePersistence.UoW.NH
{
    using NHibernate;

    /// <summary>
    /// Interface for a NHibernate implementation of Unit of Work
    /// </summary>
    public interface INHUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The database session object
        /// </summary>
        ISession Session { get; }
    }
}