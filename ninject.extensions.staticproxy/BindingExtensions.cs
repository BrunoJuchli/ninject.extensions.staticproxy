namespace Ninject.Extensions.StaticProxy
{
    using System;
    using System.Globalization;

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
            var interfaceType = typeof(T);
            EnsureTypeIsInterface(interfaceType);

            Type proxyType = RetrieveProxyType(interfaceType);

            return syntax.To(proxyType).Intercept(configure);
        }

        private static void EnsureTypeIsInterface(Type interfaceType)
        {
            if (!interfaceType.IsInterface)
            {
                string message = string.Format(
                    CultureInfo.InvariantCulture,
@"Only interfaces can be bound to a proxy with `.ToProxy(...)` and `{0}` is not an interface.
If you want to intercept a class proxy, use `.Bind<IFoo>().To<Foo>().Intercept(...)` instead.",
                    interfaceType.FullName);
                throw new InvalidOperationException(message);
            }
        }

        private static Type RetrieveProxyType(Type interfaceType)
        {
            string proxyTypeName = string.Concat(interfaceType.FullName, InterfaceImplementationSuffix);
            Type proxyType = interfaceType.Assembly.GetType(proxyTypeName);
            if (proxyType == null)
            {
                string message = string.Format(
                    CultureInfo.InvariantCulture,
@"There is no auto-generated implementation for interface `{0}`.
Verify the following:
 - Put the attribute [StaticProxy] on the interface '{0}'. The attribute can be found in the nuget package `StaticProxy.Interceptor`.
 - Add the nuget packages `Fody` and `StaticProxy.Fody` to the assembly containing the interface `{0}`
As a result there should be a class named `{1}` in the same assembly as the interface",
                    interfaceType.FullName,
                    proxyTypeName);

                throw new InvalidOperationException(message);
            }

            return proxyType;
        }
    }
}