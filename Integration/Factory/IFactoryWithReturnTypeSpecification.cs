using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithReturnTypeSpecification
    {
        [ResolveTo(typeof(InterfaceReturnTypeImplementationBar))]
        IInterfaceReturnType Create();
    }

    [StaticProxy]
    public interface IInterfaceReturnType
    {
    }

    public class InterfaceReturnTypeImplementationFoo : IInterfaceReturnType
    {
    }

    public class InterfaceReturnTypeImplementationBar : IInterfaceReturnType
    {
    }
}