namespace Ninject.Extensions.StaticProxy.Factory
{
    using Ninject.Planning.Bindings;
    using System;

    // todo implement example and create integration test

    /// <summary>
    /// <c>Used to create constraints for the resolution.</c>
    /// Attributes implementing this interface need to specified with <c>AttributeTargets.Method</c>.
    /// </summary>
    public interface IConstraintAttribute
    {
        Func<IBindingMetadata, bool> Constraint { get; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public abstract class ConstraintAttribute : Attribute, IConstraintAttribute
    {
        public abstract Func<IBindingMetadata, bool> Constraint { get; }
    }
}