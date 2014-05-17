namespace Ninject.Extensions.StaticProxy.Factory
{
    using System.Collections.Generic;

    using Ninject.Parameters;

    public interface IParameterAttribute
    {
        IEnumerable<IParameter> RetrieveParameters(ArgumentData argument);
    }
}