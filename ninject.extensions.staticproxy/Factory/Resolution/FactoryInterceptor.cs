namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    using Ninject.Syntax;

    internal class FactoryInterceptor : IDynamicInterceptor
    {
        private readonly IResolutionRoot resolutionRoot;
        private readonly IAttributesInterpreter attributesInterpreter;
        private readonly IInstanceResolver instanceResolver;

        public FactoryInterceptor(IResolutionRoot resolutionRoot, IAttributesInterpreter attributesInterpreter, IInstanceResolver instanceResolver)
        {
            this.resolutionRoot = resolutionRoot;
            this.attributesInterpreter = attributesInterpreter;
            this.instanceResolver = instanceResolver;
        }

        public void Intercept(IInvocation invocation)
        {
            IResolutionParameters resolutionParameters = this.attributesInterpreter.Interpret(invocation);
            invocation.ReturnValue = this.instanceResolver.Resolve(this.resolutionRoot, resolutionParameters);
        }
    }
}