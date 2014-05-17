namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;
    using System.Collections.Generic;

    using Ninject.Parameters;

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class NamedAttribute : Attribute, IParameterAttribute
    {
        public NamedAttribute(bool inherited)
        {
            this.Inherited = inherited;
        }

        public bool Inherited { get; private set; }
        
        public IEnumerable<IParameter> RetrieveParameters(ArgumentData argument)
        {
            yield return new ConstructorArgument(argument.ParameterName, argument.ArgumentValue, this.Inherited);
        }
    }
}