namespace Ninject.Extensions.StaticProxy
{
    using System;

    using global::StaticProxy.Interceptor.InterfaceProxy;

    using Ninject.Extensions.StaticProxy.SyntaxImplementation;
    using Ninject.Syntax;

    public static class BindingExtensions
    {
        private const string InterfaceImplementationSuffix = "Implementation";

        public static IBindingWhenInNamedWithOrOnSyntax<TImplementation> Intercept<TImplementation>(this IBindingWhenInNamedWithOrOnSyntax<TImplementation> syntax, Action<IInterceptorBindingSyntax> configure)
        {
            var interceptorSyntax = new InterceptorBindingSyntax();
            configure(interceptorSyntax);

            syntax.WithParameter(interceptorSyntax.Build());

            return syntax;
        }

        public static IBindingWhenInNamedWithOrOnSyntax<T> ToProxy<T>(this IBindingToSyntax<T> syntax, Action<IInterceptorBindingSyntax> configure)
            where T : class
        {
            Type proxyType = InterfaceProxyHelpers.GetImplementationTypeOfInterface(typeof(T));

            return syntax.To(proxyType).Intercept(configure);
        }
    }
}