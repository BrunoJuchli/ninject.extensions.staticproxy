namespace Ninject.Extensions.StaticProxy
{
    using System;
    using Ninject.Syntax;

    public static class BindingExtensions
    {
        public static void Intercept<TImplementation>(this IBindingRoot bindingRoot, Action<IInterceptorBindingSyntax> configure)
        {
            configure(new InterceptorBindingSyntax<TImplementation>(bindingRoot));
        }

        public static IBindingWhenInNamedWithOrOnSyntax<TImplementation> Intercept<TImplementation>(this IBindingWhenInNamedWithOrOnSyntax<TImplementation> syntax, Action<IInterceptorBindingSyntax> configure)
        {
            syntax.Kernel.Intercept<TImplementation>(configure);
            return syntax;
        }
    }
}