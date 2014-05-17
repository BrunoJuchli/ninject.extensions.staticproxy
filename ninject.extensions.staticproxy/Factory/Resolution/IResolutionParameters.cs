namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    using System;
    using System.Collections.Generic;

    using Ninject.Parameters;
    using Ninject.Planning.Bindings;

    internal interface IResolutionParameters
    {
        Type TypeToResolve { get; }

        Func<IBindingMetadata, bool> Constraint { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}