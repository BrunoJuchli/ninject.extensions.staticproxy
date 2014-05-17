namespace Ninject.Extensions.StaticProxy.Utilities
{
    using System.Collections.Generic;

    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> elementsToAdd)
        {
            foreach (T element in elementsToAdd)
            {
                collection.Add(element);
            }
        }
    }
}