using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithNameMatchingConstructorArgument
    {
        SingleArgumentReturnType Create([NamedConstructorArgument] string value);

        InheritedArgumentReturnType CreateWithInheritedArgument([NamedConstructorArgument(true)] string value);
    }
}