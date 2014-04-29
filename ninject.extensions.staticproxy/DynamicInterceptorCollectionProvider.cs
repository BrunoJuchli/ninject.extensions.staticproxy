namespace Ninject.Extensions.StaticProxy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Ninject.Activation;

    internal class DynamicInterceptorCollectionProvider : Provider<IDynamicInterceptorCollection>
    {
        protected override IDynamicInterceptorCollection CreateInstance(IContext context)
        {
            DynamicInterceptorParameter parameter =
                context.Request.ParentRequest.ParentContext.Parameters.OfType<DynamicInterceptorParameter>()
                    .SingleOrDefault();

            if (parameter == null)
            {
                throw new InvalidOperationException("Make sure to use interceptor syntax on interceptor binding");
            }

            IEnumerable<IDynamicInterceptor> interceptors = parameter.GetValue(context);
            return new InterceptorsCollection(interceptors);
        }

        private class InterceptorsCollection : IDynamicInterceptorCollection
        {
            private readonly IEnumerable<IDynamicInterceptor> enumerable;

            public InterceptorsCollection(IEnumerable<IDynamicInterceptor> enumerable)
            {
                this.enumerable = enumerable;
            }

            public IEnumerator<IDynamicInterceptor> GetEnumerator()
            {
                return this.enumerable.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}