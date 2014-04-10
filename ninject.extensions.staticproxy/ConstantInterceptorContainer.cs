namespace Ninject.Extensions.StaticProxy
{
    internal class ConstantInterceptorContainer<TTargetInterface> : IPerInstanceInterceptorContainer<TTargetInterface>
    {
        public ConstantInterceptorContainer(IDynamicInterceptor interceptor, int order)
        {
            this.Interceptor = interceptor;
            this.Order = order;
        }

        public IDynamicInterceptor Interceptor { get; private set; }

        public int Order { get; private set; }
    }
}