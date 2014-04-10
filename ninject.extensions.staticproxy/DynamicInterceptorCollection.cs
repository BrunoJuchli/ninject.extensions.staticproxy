namespace Ninject.Extensions.StaticProxy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class DynamicInterceptorCollection<TTarget> : IDynamicInterceptorCollection
    {
        private readonly IDynamicInterceptor[] interceptors;

        public DynamicInterceptorCollection(IEnumerable<IPerInstanceInterceptorContainer<TTarget>> interceptorContainers)
        {
            this.interceptors = interceptorContainers
                .ToArray()
                .OrderBy(x => x.Order)
                .Select(x => x.Interceptor)
                .ToArray();
        }

        public IEnumerator<IDynamicInterceptor> GetEnumerator()
        {
            return ((IEnumerable<IDynamicInterceptor>)this.interceptors).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}