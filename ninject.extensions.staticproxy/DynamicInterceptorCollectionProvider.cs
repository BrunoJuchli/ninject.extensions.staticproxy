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

            // todo: this is the interface type, not the implementation type! but binding is done on interface type :/
            // investigate how this would work with advice?!
            Type concreteCollectionType = InterceptionCollectionType.MakeGenericType(proxyType);

            return (IDynamicInterceptorCollection)context.Kernel.Get(concreteCollectionType);

        }
    }
}