namespace Ninject.Extensions.StaticProxy
{
    using System;
    using Ninject.Activation;

    internal class DynamicInterceptorCollectionProvider : Provider<IDynamicInterceptorCollection>
    {
        private static readonly Type InterceptionCollectionType = typeof(DynamicInterceptorCollection<>);

        protected override IDynamicInterceptorCollection CreateInstance(IContext context)
        {
            // Request is for IDynamicInterceptorCollection
            // ParentRequest ist for IDynamicInterceptorManager
            // ParentRequest.ParentRequest is for proxy
            Type proxyType = context.Request.ParentRequest.ParentRequest.Service;

            Type concreteCollectionType = InterceptionCollectionType.MakeGenericType(proxyType);

            return (IDynamicInterceptorCollection)context.Kernel.Get(concreteCollectionType);

        }
    }
}