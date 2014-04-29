namespace Ninject.Extensions.StaticProxy
{
    using System;

    using Ninject.Extensions.StaticProxy.SyntaxImplementation;
    using Ninject.Syntax;

    public static class BindingExtensions
    {
        public static IBindingWhenInNamedWithOrOnSyntax<TImplementation> Intercept<TImplementation>(this IBindingWhenInNamedWithOrOnSyntax<TImplementation> syntax, Action<IInterceptorBindingSyntax> configure)
        {
            var interceptorSyntax = new InterceptorBindingSyntax();
            configure(interceptorSyntax);

            syntax.WithParameter(interceptorSyntax.Build());

            return syntax;
        }
    }
}