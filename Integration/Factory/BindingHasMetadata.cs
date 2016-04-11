using Ninject.Extensions.StaticProxy.Factory;
using Ninject.Planning.Bindings;
using System;

namespace Integration.Factory
{
    public sealed class BindingHasMetadata : ConstraintAttribute
    {
        public BindingHasMetadata(string key)
        {
            Constraint = m => m.Has(key);
        }

        public override Func<IBindingMetadata, bool> Constraint { get; }
    }
}