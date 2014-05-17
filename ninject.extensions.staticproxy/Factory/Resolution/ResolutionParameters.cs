namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    using System;
    using System.Collections.Generic;

    using Ninject.Parameters;
    using Ninject.Planning.Bindings;

    internal class ResolutionParameters : IResolutionParameters
    {
        public Type TypeToResolve { get; set; }

        public Func<IBindingMetadata, bool> Constraint { get; set; }

        public IEnumerable<IParameter> Parameters { get; set; }
    }
}