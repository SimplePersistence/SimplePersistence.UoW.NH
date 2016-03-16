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
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<decimal> AverageAsync(Expression<Func<T, decimal>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<decimal> AverageAsync(Expression<Func<T, decimal>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<decimal?> AverageAsync(Expression<Func<T, decimal?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<decimal?> AverageAsync(Expression<Func<T, decimal?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<double> AverageAsync(Expression<Func<T, int>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<double> AverageAsync(Expression<Func<T, int>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<double?> AverageAsync(Expression<Func<T, int?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<double?> AverageAsync(Expression<Func<T, int?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<double> AverageAsync(Expression<Func<T, long>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<double> AverageAsync(Expression<Func<T, long>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<double?> AverageAsync(Expression<Func<T, long?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<double?> AverageAsync(Expression<Func<T, long?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<double> AverageAsync(Expression<Func<T, double>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<double> AverageAsync(Expression<Func<T, double>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<double?> AverageAsync(Expression<Func<T, double?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<double?> AverageAsync(Expression<Func<T, double?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<float> AverageAsync(Expression<Func<T, float>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<float> AverageAsync(Expression<Func<T, float>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained
        ///                 by invoking a projection function on each element of the input sequence.
        /// </summary>
        /// <param name="selector">A projection function to apply to each element. </param>
        /// <param name="ct">A <see cref="T:System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        ///                 The task result contains the average of the projected values.
        /// </returns>
#if NET40
        public Task<float?> AverageAsync(Expression<Func<T, float?>> selector, CancellationToken ct = new CancellationToken())
        {
            return Task.Factory.StartNew(() => _queryable.Average(selector), ct);
        }
#else
        public async Task<float?> AverageAsync(Expression<Func<T, float?>> selector, CancellationToken ct = new CancellationToken())
        {
            return await Task.Run(() => _queryable.Average(selector), ct);
        }
#endif
    }
}
