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
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using NHibernate;
    using NHibernate.Linq;

    public abstract class NHQueryableRepository<TEntity, TKey> : INHRepository<TEntity, TKey>
        where TEntity : class
    {
        /// <summary>
        /// Creates a new repository
        /// </summary>
        /// <param name="session">The database session</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected NHQueryableRepository(ISession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            Session = session;
        }

        #region Implementation of IAsyncRepository<TEntity,in TKey>

        /// <summary>
        /// Gets an entity by its unique identifier from this repository asynchronously
        /// </summary>
        /// <param name="id">The entity unique identifier</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task"/> that will fetch the entity
        /// </returns>
#if NET40
        public Task<TEntity> GetByIdAsync(TKey id)
        {
            return GetByIdAsync(id, CancellationToken.None);
        }
#else
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await GetByIdAsync(id, CancellationToken.None);
        }
#endif

        /// <summary>
        /// Gets an entity by its unique identifier from this repository asynchronously
        /// </summary>
        /// <param name="id">The entity unique identifier</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> that will fetch the entity
        /// </returns>
#if NET40
        public Task<TEntity> GetByIdAsync(TKey id, CancellationToken ct)
        {
            return Task.Factory.StartNew(() => GetById(id), ct);
        }
#else
        public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken ct)
        {
            return await Task.Run(() => GetById(id), ct);
        }
#endif

        /// <summary>
        /// Adds the entity to the repository asynchronously
        /// </summary>
        /// <param name="entity">The entity to add</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entity
        /// </returns>
#if NET40
        public Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => Add(entity), ct);
        }
#else
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => Add(entity), ct);
        }
#endif

        /// <summary>
        /// Adds a range of entities to the repository asynchronously
        /// </summary>
        /// <param name="entities">The entity to add</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities, CancellationToken ct = new CancellationToken())
        {
            return AddAsync(ct, entities as TEntity[] ?? entities.ToArray());
        }
#else
        public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities, CancellationToken ct = new CancellationToken())
        {
            return await AddAsync(ct, entities as TEntity[] ?? entities.ToArray());
        }
#endif

        /// <summary>
        /// Adds a range of entities to the repository asynchronously
        /// </summary>
        /// <param name="entities">The entity to add</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> AddAsync(params TEntity[] entities)
        {
            return AddAsync(CancellationToken.None, entities);
        }
#else
        public async Task<IEnumerable<TEntity>> AddAsync(params TEntity[] entities)
        {
            return await AddAsync(CancellationToken.None, entities);
        }
#endif

        /// <summary>
        /// Adds a range of entities to the repository asynchronously
        /// </summary>
        /// <param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param><param name="entities">The entity to add</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> AddAsync(CancellationToken ct, params TEntity[] entities)
        {
            return Task.Factory.StartNew(() => Add(entities), ct);
        }
#else
        public async Task<IEnumerable<TEntity>> AddAsync(CancellationToken ct, params TEntity[] entities)
        {
            return await Task.Run(() => Add(entities), ct);
        }
#endif

        /// <summary>
        /// Updates the entity in the repository asynchronously
        /// </summary>
        /// <param name="entity">The entity to update</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entity
        /// </returns>
#if NET40
        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => Update(entity), ct);
        }
#else
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => Update(entity), ct);
        }
#endif

        /// <summary>
        /// Updates a range of entities in the repository asynchronously
        /// </summary>
        /// <param name="entities">The entities to update</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken ct = new CancellationToken())
        {
            return UpdateAsync(ct, entities as TEntity[] ?? entities.ToArray());
        }
#else
        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken ct = new CancellationToken())
        {
            return await UpdateAsync(ct, entities as TEntity[] ?? entities.ToArray());
        }
#endif

        /// <summary>
        /// Updates a range of entities in the repository asynchronously
        /// </summary>
        /// <param name="entities">The entities to update</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> UpdateAsync(params TEntity[] entities)
        {
            return UpdateAsync(CancellationToken.None, entities);
        }
#else
        public async Task<IEnumerable<TEntity>> UpdateAsync(params TEntity[] entities)
        {
            return await UpdateAsync(CancellationToken.None, entities);
        }
#endif

        /// <summary>
        /// Updates a range of entities in the repository asynchronously
        /// </summary>
        /// <param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param><param name="entities">The entities to update</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> UpdateAsync(CancellationToken ct, params TEntity[] entities)
        {
            return Task.Factory.StartNew(() => Update(entities), ct);
        }
#else
        public async Task<IEnumerable<TEntity>> UpdateAsync(CancellationToken ct, params TEntity[] entities)
        {
            return await Task.Run(() => Update(entities), ct);
        }
#endif

        /// <summary>
        /// Deletes the entity in the repository asynchronously
        /// </summary>
        /// <param name="entity">The entity to delete</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entity
        /// </returns>
#if NET40
        public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => Delete(entity), ct);
        }
#else
        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => Delete(entity), ct);
        }
#endif

        /// <summary>
        /// Deletes a range of entity in the repository asynchronously
        /// </summary>
        /// <param name="entities">The entities to delete</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> DeleteAsync(IEnumerable<TEntity> entities, CancellationToken ct = new CancellationToken())
        {
            return DeleteAsync(ct, entities as TEntity[] ?? entities.ToArray());
        }
#else
        public async Task<IEnumerable<TEntity>> DeleteAsync(IEnumerable<TEntity> entities, CancellationToken ct = new CancellationToken())
        {
            return await DeleteAsync(ct, entities as TEntity[] ?? entities.ToArray());
        }
#endif

        /// <summary>
        /// Deletes a range of entity in the repository asynchronously
        /// </summary>
        /// <param name="entities">The entities to delete</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> DeleteAsync(params TEntity[] entities)
        {
            return DeleteAsync(CancellationToken.None, entities);
        }
#else
        public async Task<IEnumerable<TEntity>> DeleteAsync(params TEntity[] entities)
        {
            return await DeleteAsync(CancellationToken.None, entities);
        }
#endif

        /// <summary>
        /// Deletes a range of entity in the repository asynchronously
        /// </summary>
        /// <param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param><param name="entities">The entities to delete</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the entities
        /// </returns>
#if NET40
        public Task<IEnumerable<TEntity>> DeleteAsync(CancellationToken ct, params TEntity[] entities)
        {
            return Task.Factory.StartNew(() => Delete(entities), ct);
        }
#else
        public async Task<IEnumerable<TEntity>> DeleteAsync(CancellationToken ct, params TEntity[] entities)
        {
            return await Task.Run(() => Delete(entities), ct);
        }
#endif

        /// <summary>
        /// Gets the total entities in the repository asynchronously
        /// </summary>
        /// <param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task`1"/> containing the total
        /// </returns>
#if NET40
        public Task<long> TotalAsync(CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(Total, ct);
        }
#else
        public async Task<long> TotalAsync(CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => Total(), ct);
        }
#endif

        /// <summary>
        /// Checks if an entity with the given key exists
        /// </summary>
        /// <param name="id">The entity unique identifier</param><param name="ct">The <see cref="T:System.Threading.CancellationToken"/> for the returned task</param>
        /// <returns>
        /// True if entity exists
        /// </returns>
#if NET40
        public Task<bool> ExistsAsync(TKey id, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => Exists(id), ct);
        }
#else
        public async Task<bool> ExistsAsync(TKey id, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => Exists(id), ct);
        }
#endif

        #endregion

        #region Implementation of ISyncRepository<TEntity,in TKey>

        /// <summary>
        /// Gets an entity by its unique identifier from this repository
        /// </summary>
        /// <param name="id">The entity unique identifier</param>
        /// <returns>
        /// The entity or null if not found
        /// </returns>
        public TEntity GetById(TKey id)
        {
            return Session.Get<TEntity>(id);
        }

        /// <summary>
        /// Adds the entity to the repository
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns>
        /// The entity
        /// </returns>
        public TEntity Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Session.Save(entity);
            return entity;
        }

        /// <summary>
        /// Adds a range of entities to the repository
        /// </summary>
        /// <param name="entities">The entities to add</param>
        /// <returns>
        /// The range of entities added
        /// </returns>
        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            return Add(entities as TEntity[] ?? entities.ToArray());
        }

        /// <summary>
        /// Adds a range of entities to the repository
        /// </summary>
        /// <param name="entities">The entities to add</param>
        /// <returns>
        /// The range of entities added
        /// </returns>
        public IEnumerable<TEntity> Add(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var result = new TEntity[entities.Length];
            for (var i = 0; i < entities.Length; i++)
            {
                result[i] = Add(entities[i]);
            }
            return result;
        }

        /// <summary>
        /// Updates the entity in the repository
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns>
        /// The entity
        /// </returns>
        public TEntity Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Session.Update(entity);
            return entity;
        }

        /// <summary>
        /// Updates a range of entities in the repository
        /// </summary>
        /// <param name="entities">The entities to update</param>
        /// <returns>
        /// The entities
        /// </returns>
        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            return Update(entities as TEntity[] ?? entities.ToArray());
        }

        /// <summary>
        /// Updates a range of entities in the repository
        /// </summary>
        /// <param name="entities">The entities to update</param>
        /// <returns>
        /// The entities
        /// </returns>
        public IEnumerable<TEntity> Update(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var result = new TEntity[entities.Length];
            for (var i = 0; i < entities.Length; i++)
            {
                result[i] = Update(entities[i]);
            }
            return result;
        }

        /// <summary>
        /// Deletes the entity in the repository
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>
        /// The entity
        /// </returns>
        public TEntity Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Session.Delete(entity);
            return entity;
        }

        /// <summary>
        /// Deletes a range of entity in the repository
        /// </summary>
        /// <param name="entities">The entities to delete</param>
        /// <returns>
        /// The entities
        /// </returns>
        public IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            return Delete(entities as TEntity[] ?? entities.ToArray());
        }

        /// <summary>
        /// Deletes a range of entity in the repository
        /// </summary>
        /// <param name="entities">The entities to delete</param>
        /// <returns>
        /// The entities
        /// </returns>
        public IEnumerable<TEntity> Delete(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var result = new TEntity[entities.Length];
            for (var i = 0; i < entities.Length; i++)
            {
                result[i] = Delete(entities[i]);
            }
            return result;
        }

        /// <summary>
        /// Gets the total entities in the repository
        /// </summary>
        /// <returns>
        /// The total
        /// </returns>
        public long Total()
        {
            return Session.QueryOver<TEntity>().RowCountInt64();
        }

        /// <summary>
        /// Checks if an entity with the given key exists
        /// </summary>
        /// <param name="id">The entity unique identifier</param>
        /// <returns>
        /// True if entity exists
        /// </returns>
        public bool Exists(TKey id)
        {
            return QueryById(id).Any();
        }

        #endregion

        #region Implementation of IExposeQueryable<TEntity,in TKey>

        /// <summary>
        /// Gets an <see cref="T:System.Linq.IQueryable`1"/>
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryable`1"/> object
        /// </returns>
        public IQueryable<TEntity> Query()
        {
            return Session.Query<TEntity>();
        }

        /// <summary>
        /// Gets an <see cref="T:System.Linq.IQueryable`1"/> filtered by
        ///             the entity id
        /// </summary>
        /// <param name="id">The entity unique identifier</param>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryable`1"/> object
        /// </returns>
        public abstract IQueryable<TEntity> QueryById(TKey id);

        /// <summary>
        /// Gets an <see cref="T:System.Linq.IQueryable`1"/> 
        ///             that will also fetch, on execution, all the entity navigation properties
        /// </summary>
        /// <param name="propertiesToFetch">The navigation properties to also fetch on query execution</param>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryable`1"/> object
        /// </returns>
        public IQueryable<TEntity> QueryFetching(params Expression<Func<TEntity, object>>[] propertiesToFetch)
        {
            if (propertiesToFetch == null) throw new ArgumentNullException(nameof(propertiesToFetch));

            return propertiesToFetch.Aggregate(Query(), (current, expression) => current.Fetch(expression));
        }

        #endregion

        #region Implementation of INHRepository<TEntity,in TKey>

        /// <summary>
        /// The database session object
        /// </summary>
        public ISession Session { get; }

        #endregion
    }
}
