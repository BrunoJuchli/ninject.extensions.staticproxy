namespace Ninject.Extensions.StaticProxy
{

    internal class PerInstanceInterceptorContainer<TTargetInterface, TInterceptor> : IPerInstanceInterceptorContainer<TTargetInterface>
        where TInterceptor : IDynamicInterceptor
    {
        public PerInstanceInterceptorContainer(TInterceptor interceptor)
        {
            this.Interceptor = interceptor;

            this.Order = int.MaxValue;
        }

        public IDynamicInterceptor Interceptor { get; private set; }

        public int Order { get; set; }
    }
}