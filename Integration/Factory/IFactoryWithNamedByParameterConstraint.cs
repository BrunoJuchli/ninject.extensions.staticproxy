using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithNamedByParameterConstraint
    {
        IInterfaceReturnType CreateNamed([NamedConstraintByParameter]string name);
    }
}