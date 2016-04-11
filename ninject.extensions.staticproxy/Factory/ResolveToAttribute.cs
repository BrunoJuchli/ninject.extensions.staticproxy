namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    public sealed class ResolveToAttribute : ReturnTypeAttribute
    {
        public ResolveToAttribute(Type implementationType)
        {
            this.ReturnType = implementationType;
        }

        public override Type ReturnType { get; }
    }
}