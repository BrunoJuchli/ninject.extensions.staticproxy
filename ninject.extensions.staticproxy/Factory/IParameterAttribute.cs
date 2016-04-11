using System;

namespace Ninject.Extensions.StaticProxy.Factory
{
    using Ninject.Parameters;
    using System.Collections.Generic;

    /// <summary>
    /// <c>Converts a factory method parameter into a resolution parameter</c>
    /// </summary>
    public interface IParameterAttribute
    {
        IEnumerable<IParameter> RetrieveParameters(ArgumentData argument);
    }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class ParameterAttribute : Attribute, IParameterAttribute
    {
        public abstract IEnumerable<IParameter> RetrieveParameters(ArgumentData argument);
    }
}