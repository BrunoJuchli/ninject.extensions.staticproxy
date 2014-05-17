namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    using Ninject.Planning.Bindings;

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class NameAttribute : Attribute, IParameterisedConstraintAttribute
    {
        public Func<IBindingMetadata, bool> CreateConstraint(ArgumentData argument)
        {
            var name = (string)argument.ArgumentValue;

            return x => x.Name == name;
        }
    }
}