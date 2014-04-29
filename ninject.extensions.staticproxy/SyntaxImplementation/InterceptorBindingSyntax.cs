namespace Ninject.Extensions.StaticProxy.SyntaxImplementation
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Ninject.Extensions.StaticProxy.InterceptorContainer;

    internal class InterceptorBindingSyntax : IInterceptorBindingSyntax
    {
        private const int DefaultInterceptorOrder = int.MaxValue;

        private readonly ICollection<IPerInstanceInterceptorContainerWithOrder> interceptors = new Collection<IPerInstanceInterceptorContainerWithOrder>();
        
        public IInterceptorBindingSyntax By<TInterceptor>() 
            where TInterceptor : IDynamicInterceptor
        {
            return this.By<TInterceptor>(DefaultInterceptorOrder);
        }

        public IInterceptorBindingSyntax By<TInterceptor>(int order) 
            where TInterceptor : IDynamicInterceptor
        {
            this.interceptors.Add(new OnActivationInterceptorInstanciatingContainer<TInterceptor>(order));
            return this;
        }

        public IInterceptorBindingSyntax By(IDynamicInterceptor interceptor)
        {
            return this.By(interceptor, DefaultInterceptorOrder);
        }

        public IInterceptorBindingSyntax By(IDynamicInterceptor interceptor, int order)
        {
            this.interceptors.Add(new ConstantInterceptorContainer(order, interceptor));
            return this;
        }

        public DynamicInterceptorParameter Build()
        {
            return new DynamicInterceptorParameter(
                this.interceptors
                .OrderBy(x => x.Order)
                .OfType<IPerInstanceInterceptorContainer>()
                .ToList());
        }
    }
}