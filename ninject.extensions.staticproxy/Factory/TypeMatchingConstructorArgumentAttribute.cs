using Ninject.Parameters;
using System.Collections.Generic;

namespace Ninject.Extensions.StaticProxy.Factory
{
    public sealed class TypeMatchingConstructorArgumentAttribute : ParameterAttribute
    {
        public TypeMatchingConstructorArgumentAttribute(bool inherited)
        {
            Inherited = inherited;
        }

        public TypeMatchingConstructorArgumentAttribute()
            : this(false)
        {

        }

        public bool Inherited { get; }

        public override IEnumerable<IParameter> RetrieveParameters(ArgumentData argument)
        {
            yield return CreateTypeMatchingConstructorArgument(argument, this.Inherited);
        }

        internal static TypeMatchingConstructorArgument CreateTypeMatchingConstructorArgument(
            ArgumentData argument,
            bool inherited)
        {
            return new TypeMatchingConstructorArgument(
                argument.ParameterType,
                (ctx, target) => argument.ArgumentValue,
                inherited);
        }
    }
}