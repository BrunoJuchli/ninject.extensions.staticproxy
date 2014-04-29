namespace Ninject.Extensions.StaticProxy.InterceptorContainer
{
    internal interface IPerInstanceInterceptorContainerWithOrder : IPerInstanceInterceptorContainer
    {
        int Order { get; }
    }
}