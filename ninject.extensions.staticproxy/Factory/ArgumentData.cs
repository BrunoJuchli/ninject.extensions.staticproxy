namespace Ninject.Extensions.StaticProxy.Factory
{
    using System;

    public class ArgumentData
    {
        public object ArgumentValue { get; set; }

        public string ParameterName { get; set; }

        public Type ParameterType { get; set; } 
    }
}