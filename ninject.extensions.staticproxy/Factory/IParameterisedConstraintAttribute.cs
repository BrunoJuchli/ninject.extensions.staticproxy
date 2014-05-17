namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    using Ninject.Planning.Bindings;

    public interface IParameterisedConstraintAttribute
    {
        Func<IBindingMetadata, bool> CreateConstraint(ArgumentData argument);
    }
}