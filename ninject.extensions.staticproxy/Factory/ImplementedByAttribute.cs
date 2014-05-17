namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class ImplementedByAttribute : Attribute, IReturnTypeAttribute
    {
        public ImplementedByAttribute(Type implementationType)
        {
            this.ReturnType = implementationType;
        }

        public Type ReturnType { get; private set; }
    }
}