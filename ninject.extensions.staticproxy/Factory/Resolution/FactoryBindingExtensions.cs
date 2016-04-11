using Ninject.Syntax;
using System;
using System.Reflection;

namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    public static class FactoryBindingExtensions
    {
        public static IBindingWhenInNamedWithOrOnSyntax<T> ToFactory<T>(this IBindingToSyntax<T> syntax)
            where T : class
        {
            Type interfaceType = typeof(T);
            if (!interfaceType.GetTypeInfo().IsInterface)
            {
                throw new NotSupportedException("only interfaces can be bound ");
            }

            return syntax.ToProxy(intercept => intercept.By<FactoryInterceptor>());
        }
    }
}