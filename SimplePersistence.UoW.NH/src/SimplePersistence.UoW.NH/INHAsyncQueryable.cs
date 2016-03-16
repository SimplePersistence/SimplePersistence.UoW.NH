namespace SimplePersistence.UoW.NH
{
    using System.Linq;

    /// <summary>
    /// Specialized <see cref="IQueryable{T}"/> for async executions using the NHibernate.
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    public interface INHAsyncQueryable<T> : IAsyncQueryable<T>
    {
        
    }
}