namespace Ninject.Extensions.StaticProxy.InterceptorContainer
{
    using Ninject.Activation;

    internal class OnActivationInterceptorInstanciatingContainer<TInterceptor> : IPerInstanceInterceptorContainerWithOrder
        where TInterceptor : IDynamicInterceptor
    {
        public OnActivationInterceptorInstanciatingContainer(int order)
        {
            this.Order = order;
        }

        public int Order { get; set; }

        public IDynamicInterceptor RetrieveInterceptor(IContext context)
        {
            return context.Kernel.Get<TInterceptor>();
        }
    }
}