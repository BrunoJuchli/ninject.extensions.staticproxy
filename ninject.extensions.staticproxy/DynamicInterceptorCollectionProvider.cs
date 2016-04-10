using System.Reflection;

namespace Ninject.Extensions.StaticProxy
{
    using Ninject.Activation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class DynamicInterceptorCollectionProvider : Provider<IDynamicInterceptorCollection>
    {
        protected override IDynamicInterceptorCollection CreateInstance(IContext context)
        {
            DynamicInterceptorParameter parameter = RetrieveDynamicInterceptorParameter(context);
            IEnumerable<IDynamicInterceptor> interceptors = parameter.GetValue(context);
            return new InterceptorsCollection(interceptors);
        }

        private static DynamicInterceptorParameter RetrieveDynamicInterceptorParameter(IContext context)
        {
            IContext proxyServiceContext = context.Request.ParentRequest.ParentContext;

            DynamicInterceptorParameter parameter =
                proxyServiceContext.Parameters.OfType<DynamicInterceptorParameter>().SingleOrDefault();

            AssertParameterIsNotNull(parameter, proxyServiceContext);

            return parameter;
        }

        private static void AssertParameterIsNotNull(DynamicInterceptorParameter parameter, IContext proxyServiceContext)
        {
            if (parameter == null)
            {
                Type requestedProxyServiceType = proxyServiceContext.Request.Service;
                string messageFormat;
                if (requestedProxyServiceType.GetTypeInfo().IsInterface)
                {
                    messageFormat = @"Missing Parameter of type `{0}` on request for `{1}`.
Please make sure you bind `{1}` using the appropriate way.
If you want to use interception with a base-implementation (class proxy) use:
 - .Bind<{2}>().To<>().Intercept(x => ...);
If you want to use interception without a base implementation (interface proxy) use:
 - .Bind<{2}>().ToProxy(x => ...);";
                }
                else
                {
                    messageFormat = @"Missing Parameter of type `{0}` on request for `{1}`.
Please make sure you bind `{1}` using the appropriate way. Which is:
  - .Bind<{2}>().ToSelf().Intercept(x => ...);";
                }

                string message = string.Format(
                    CultureInfo.InvariantCulture,
                    messageFormat,
                    typeof(DynamicInterceptorParameter).FullName,
                    requestedProxyServiceType.FullName,
                    requestedProxyServiceType.Name);

                throw new InvalidOperationException(message);
            }
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