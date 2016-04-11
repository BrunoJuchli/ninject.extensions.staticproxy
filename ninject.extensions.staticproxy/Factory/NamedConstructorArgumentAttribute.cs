namespace Ninject.Extensions.StaticProxy.Factory
{
    using Ninject.Parameters;
    using System.Collections.Generic;


    public sealed class NamedConstructorArgumentAttribute : ParameterAttribute
    {
        public NamedConstructorArgumentAttribute(bool inherited)
        {
            this.Inherited = inherited;
        }

        public NamedConstructorArgumentAttribute()
            : this(false)
        {
        }

        public bool Inherited { get; }

        public override IEnumerable<IParameter> RetrieveParameters(ArgumentData argument)
        {
            yield return new ConstructorArgument(argument.ParameterName, argument.ArgumentValue, this.Inherited);
        }
    }
}