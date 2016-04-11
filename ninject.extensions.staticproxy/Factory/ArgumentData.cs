namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    public class ArgumentData
    {
        public ArgumentData(object argumentValue, string parameterName, Type parameterType)
        {
            ArgumentValue = argumentValue;
            ParameterName = parameterName;
            ParameterType = parameterType;
        }


        public object ArgumentValue { get; }

        public string ParameterName { get; }

        public Type ParameterType { get; }
    }
}