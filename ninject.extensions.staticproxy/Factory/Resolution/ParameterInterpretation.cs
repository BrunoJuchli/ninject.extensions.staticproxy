using Ninject.Parameters;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;

namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    public class ParameterInterpretation
    {
        public ParameterInterpretation(
            IReadOnlyCollection<Func<IBindingMetadata, bool>> constraints,
            IReadOnlyCollection<IParameter> resolutionParameters)
        {
            if (constraints == null)
            {
                throw new ArgumentOutOfRangeException(nameof(constraints));
            }

            if (resolutionParameters == null)
            {
                throw new ArgumentOutOfRangeException(nameof(resolutionParameters));
            }

            this.Constraints = constraints;
            this.ResolutionParameters = resolutionParameters;
        }

        public IReadOnlyCollection<Func<IBindingMetadata, bool>> Constraints { get; }

        public IReadOnlyCollection<IParameter> ResolutionParameters { get; }
    }
}