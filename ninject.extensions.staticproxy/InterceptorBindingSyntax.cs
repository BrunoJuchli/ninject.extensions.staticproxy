namespace Ninject.Extensions.StaticProxy
{
    using Ninject.Syntax;

    internal class InterceptorBindingSyntax<TTarget> : IInterceptorBindingSyntax
    {
        private readonly IBindingRoot bindingRoot;

        public InterceptorBindingSyntax(IBindingRoot bindingRoot)
        {
            this.bindingRoot = bindingRoot;
        }

        public IInterceptorBindingSyntax By<TInterceptor>()
            where TInterceptor : IDynamicInterceptor
        {
            return this.By<TInterceptor>(int.MaxValue);
        }

        public IInterceptorBindingSyntax By<TInterceptor>(int order) where TInterceptor : IDynamicInterceptor
        {
            this.bindingRoot
                .Bind<IPerInstanceInterceptorContainer<TTarget>>()
                .To<PerInstanceInterceptorContainer<TTarget, TInterceptor>>()
                .OnActivation(x => x.Order = order);

            return this;
        }
    }
}