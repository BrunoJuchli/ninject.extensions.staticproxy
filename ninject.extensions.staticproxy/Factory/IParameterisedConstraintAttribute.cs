namespace Ninject.Extensions.StaticProxy.Factory
{
    using Ninject.Planning.Bindings;
    using System;

    /// <summary>
    /// <c>Used to create constraints for the resolution.</c> Takes a method argument as a target.
    /// Attributes implementing this interface should be specified with <c>AttributeTargets.Parameter</c>.
    /// </summary>
    public interface IParameterisedConstraintAttribute
    {
        Func<IBindingMetadata, bool> CreateConstraint(ArgumentData argument);
    }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class ParameterisedConstraintAttribute : Attribute, IParameterisedConstraintAttribute
    {
        public abstract Func<IBindingMetadata, bool> CreateConstraint(ArgumentData argument);
    }
}