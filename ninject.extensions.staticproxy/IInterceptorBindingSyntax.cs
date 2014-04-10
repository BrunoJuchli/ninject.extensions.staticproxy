namespace Ninject.Extensions.StaticProxy
{
    public interface IInterceptorBindingSyntax
    {
        IInterceptorBindingSyntax By<TInterceptor>()
            where TInterceptor : IDynamicInterceptor;

        IInterceptorBindingSyntax By<TInterceptor>(int order)
            where TInterceptor : IDynamicInterceptor;
    }
}