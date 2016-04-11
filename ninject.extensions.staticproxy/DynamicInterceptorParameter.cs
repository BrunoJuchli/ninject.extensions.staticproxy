namespace Ninject.Extensions.StaticProxy
{
    using Ninject.Activation;
    using Ninject.Extensions.StaticProxy.InterceptorContainer;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DynamicInterceptorParameter : IParameter
    {
        private readonly ICollection<IPerInstanceInterceptorContainer> interceptorContainers;

        public DynamicInterceptorParameter(ICollection<IPerInstanceInterceptorContainer> interceptorContainers)
        {
            this.interceptorContainers = interceptorContainers;
        }

        public string Name => this.GetType().Name;

        public bool ShouldInherit => false;

        public object GetValue(IContext context, ITarget target)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<IDynamicInterceptor> GetValue(IContext context)
        {
            return this.interceptorContainers.Select(x => x.RetrieveInterceptor(context));
        }

        public bool Equals(IParameter other)
        {
            return base.Equals(other);
        }
    }
}