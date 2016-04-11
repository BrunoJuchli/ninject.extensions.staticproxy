namespace Ninject.Extensions.StaticProxy.Factory
{
    using Ninject.Planning.Bindings;
    using System;

    public sealed class NamedConstraintAttribute : ParameterisedConstraintAttribute
    {
        public override Func<IBindingMetadata, bool> CreateConstraint(ArgumentData argument)
        {
            var name = (string)argument.ArgumentValue;

            return x => x.Name == name;
        }
    }
}