using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithNamedConstraint
    {
        [NamedConstraint(Constants.Bar)]
        IInterfaceReturnType CreateBar();
    }
}