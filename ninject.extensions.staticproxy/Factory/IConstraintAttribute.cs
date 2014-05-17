namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    using Ninject.Planning.Bindings;

    public interface IConstraintAttribute
    {
        Func<IBindingMetadata, bool> Constraint { get; }
    }
}