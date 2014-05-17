namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    internal interface IAttributesInterpreter
    {
        IResolutionParameters Interpret(IInvocation invocation);
    }
}