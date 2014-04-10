namespace Ninject.Extensions.StaticProxy
{
    using Ninject.Syntax;

    internal class InterceptorBindingSyntax<TTarget> : IInterceptorBindingSyntax
    {
        private const int DefaultInterceptorOrder = int.MaxValue;

        private readonly IBindingRoot bindingRoot;

        public InterceptorBindingSyntax(IBindingRoot bindingRoot)
        {
            this.bindingRoot = bindingRoot;
        }

        public IInterceptorBindingSyntax By<TInterceptor>()
            where TInterceptor : IDynamicInterceptor
        {
            return this.By<TInterceptor>(DefaultInterceptorOrder);
        }

        public IInterceptorBindingSyntax By<TInterceptor>(int order) where TInterceptor : IDynamicInterceptor
        {
            this.bindingRoot
                .Bind<IPerInstanceInterceptorContainer<TTarget>>()
                .To<OnActivationInterceptorInstanciatingContainer<TTarget, TInterceptor>>()
                .OnActivation(x => x.Order = order);

            return this;
        }

        public IInterceptorBindingSyntax By(IDynamicInterceptor interceptor)
        {
            return this.By(interceptor, DefaultInterceptorOrder);
        }

        public IInterceptorBindingSyntax By(IDynamicInterceptor interceptor, int order)
        {
            this.bindingRoot
                .Bind<IPerInstanceInterceptorContainer<TTarget>>()
                .ToConstant(new ConstantInterceptorContainer<TTarget>(interceptor, order));
            return this;
        }
    }
}