using Ninject.Planning.Bindings;
using System;

namespace Ninject.Extensions.StaticProxy.Factory
{
    public sealed class NamedConstraintAttribute : ConstraintAttribute
    {
        public NamedConstraintAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }

            this.Constraint = x => x.Name == name;
        }

        public override Func<IBindingMetadata, bool> Constraint { get; }
    }
}