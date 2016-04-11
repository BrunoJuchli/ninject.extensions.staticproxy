namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    /// <summary>
    /// <c>Specifies which type to resolve and return.</c>
    /// Attributes implementing this interface should be specified with <c>AttributeTargets.Method</c>.
    /// Even though <c>AttributeTargets.ReturnType</c> would be more correct, method-target is chosen because is results in simpler/cleaner syntax.
    /// Also see https://msdn.microsoft.com/en-us/library/b3787ac0%28v=vs.90%29.aspx
    /// </summary>
    public interface IReturnTypeAttribute
    {
        Type ReturnType { get; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class ReturnTypeAttribute : Attribute, IReturnTypeAttribute
    {
        public abstract Type ReturnType { get; }
    }
}