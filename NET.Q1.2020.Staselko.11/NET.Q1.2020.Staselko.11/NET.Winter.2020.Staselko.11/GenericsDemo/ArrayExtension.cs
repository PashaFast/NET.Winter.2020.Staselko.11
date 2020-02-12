using System;
using System.Collections.Generic;
using GenericsDemo.Interfaces;

namespace GenericsDemo
{
    /// <summary>
    /// Class ArrayExtension.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters array by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <returns>Filtered array.</returns>
        public static TSource[] FilterBy<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            IsValidationSource(source);

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            var filteredSource = new List<TSource>();

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    filteredSource.Add(item);
                }
            }

            return filteredSource.ToArray();
        }

        /// <summary>
        /// Transform array by transformer.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <typeparam name="TResult">Output parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed array.</returns>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            IsValidationSource(source);

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            int index = 0;

            var transformedSource = new TResult[source.Length];

            foreach (var item in source)
            {
                transformedSource[index++] = transformer.Transform(item);
            }

            return transformedSource;
        }

        /// <summary>
        /// Sorting array by comparer.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Sorted array.</returns>
        public static TSource[] OrderAccordingTo<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            IsValidationSource(source);

            if (comparer is null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} cannot be null.");
            }

            var sorceToSort = new TSource[source.Length];
            Array.Copy(source, sorceToSort, sorceToSort.Length);
            Array.Sort(sorceToSort, comparer);
            return sorceToSort;
        }

        /// <summary>
        ///  TypeOf method.
        /// </summary>
        /// <typeparam name="TResult">Output parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The array of objects of a certain type.</returns>
        public static TResult[] TypeOf<TResult>(this object[] source)
        {
            IsValidationSource(source);

            var result = new List<TResult>();
            foreach(var item in source)
            {
                if (item is TResult)
                {
                    result.Add((TResult)item);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Reverse method.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Reverse array.</returns>
        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            IsValidationSource(source);
            var result = new TSource[source.Length];
            int index = source.Length - 1;
            foreach (var item in source)
            {
                result[index--] = item;
            }

            return result;
        }

        private static void IsValidationSource<TSource>(TSource[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }
        }
    }
}