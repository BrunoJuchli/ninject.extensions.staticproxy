namespace Ninject.Extensions.StaticProxy
{
    using global::StaticProxy.Interceptor.InterfaceProxy;
    using Ninject.Extensions.StaticProxy.SyntaxImplementation;
    using Ninject.Syntax;
    using System;

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
            Type interfaceType = typeof(T);

            if (interfaceType == typeof(object))
            {
                throw new NotSupportedException("sorry, but IBindingRoot.Bind(typeof(IFoo)).ToProxy() style binding is currently not supported");
            }

            Type proxyType = InterfaceProxyHelpers.GetImplementationTypeOfInterface(interfaceType);

            return syntax.To(proxyType).Intercept(configure);
        }
    }
}