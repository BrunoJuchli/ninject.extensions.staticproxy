namespace Ninject.Extensions.StaticProxy.InterceptorContainer
{
    using Ninject.Activation;

    internal interface IPerInstanceInterceptorContainer
    {
        IDynamicInterceptor RetrieveInterceptor(IContext context);
    }
}