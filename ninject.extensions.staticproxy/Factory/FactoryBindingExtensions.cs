using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Ninject.Syntax;
using System;
using System.Reflection;

namespace Ninject.Extensions.StaticProxy.Factory
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