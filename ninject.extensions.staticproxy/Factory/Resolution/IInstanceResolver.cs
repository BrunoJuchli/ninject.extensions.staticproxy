namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    using Ninject.Syntax;

    internal interface IInstanceResolver
    {
        object Resolve(IResolutionRoot resolutionRoot, IResolutionParameters resolutionParameters);
    }
}