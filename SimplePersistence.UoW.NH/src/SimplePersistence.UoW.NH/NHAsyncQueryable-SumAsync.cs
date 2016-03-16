namespace SimplePersistence.UoW.NH
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class NHAsyncQueryable<T>
    {
        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<decimal> SumAsync(Expression<Func<T, decimal>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<decimal> SumAsync(Expression<Func<T, decimal>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<decimal?> SumAsync(Expression<Func<T, decimal?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<decimal?> SumAsync(Expression<Func<T, decimal?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<int> SumAsync(Expression<Func<T, int>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<int> SumAsync(Expression<Func<T, int>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<int?> SumAsync(Expression<Func<T, int?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<int?> SumAsync(Expression<Func<T, int?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<long> SumAsync(Expression<Func<T, long>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<long> SumAsync(Expression<Func<T, long>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<long?> SumAsync(Expression<Func<T, long?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<long?> SumAsync(Expression<Func<T, long?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<double> SumAsync(Expression<Func<T, double>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<double> SumAsync(Expression<Func<T, double>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<double?> SumAsync(Expression<Func<T, double?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<double?> SumAsync(Expression<Func<T, double?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<float> SumAsync(Expression<Func<T, float>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<float> SumAsync(Expression<Func<T, float>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on
        ///                 each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the sum of the projected values..
        /// </returns>
#if NET40
        public Task<float?> SumAsync(Expression<Func<T, float?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Sum(selector), ct);
        }
#else
        public async Task<float?> SumAsync(Expression<Func<T, float?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Sum(selector), ct);
        }
#endif
    }
}
