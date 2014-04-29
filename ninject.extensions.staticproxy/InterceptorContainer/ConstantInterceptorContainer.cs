namespace Ninject.Extensions.StaticProxy.InterceptorContainer
{
    using Ninject.Activation;

    internal class ConstantInterceptorContainer : IPerInstanceInterceptorContainerWithOrder
    {
        private readonly IDynamicInterceptor interceptor;

        public ConstantInterceptorContainer(int order, IDynamicInterceptor interceptor)
        {
            this.interceptor = interceptor;
            this.Order = order;
        }

        public int Order { get; private set; }

        public IDynamicInterceptor RetrieveInterceptor(IContext context)
        {
            return this.interceptor;
        }
    }
}