namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    public sealed class ImplementedByAttribute : ReturnTypeAttribute
    {
        public ImplementedByAttribute(Type implementationType)
        {
            this.ReturnType = implementationType;
        }

        public override Type ReturnType { get; }
    }
}