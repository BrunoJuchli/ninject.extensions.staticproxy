using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithMultipleConstraints
    {
        [BindingHasMetadata(Constants.Foo)]
        IInterfaceReturnType Create([NamedConstraintByParameter] string name);
    }
}