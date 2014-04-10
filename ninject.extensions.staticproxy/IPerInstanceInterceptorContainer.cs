namespace Ninject.Extensions.StaticProxy
{
    internal interface IPerInstanceInterceptorContainer<TTargetInterface>
    {
        IDynamicInterceptor Interceptor { get; }

        int Order { get; }
    }
}