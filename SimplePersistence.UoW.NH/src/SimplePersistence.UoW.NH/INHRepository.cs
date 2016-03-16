namespace SimplePersistence.UoW.NH
{
    using NHibernate;

    /// <summary>
    /// Specialized interface of an <see cref="IQueryableRepository{TEntity,TId}"/> 
    /// for the NHibernate.
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    /// <typeparam name="TKey">The entity id type</typeparam>
    public interface INHRepository<TEntity, in TKey> : IQueryableRepository<TEntity, TKey>
        where TEntity : class
    {
        /// <summary>
        /// The database session object
        /// </summary>
        ISession Session { get; }
    }
}