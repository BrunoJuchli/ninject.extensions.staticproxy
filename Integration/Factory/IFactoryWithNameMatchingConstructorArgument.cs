using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithNameMatchingConstructorArgument
    {
        SingleArgumentReturnType Create([NamedConstructorArgument] string value);

        InheritedArgumentReturnType CreatedWithDependencyAndNotInheritedArgument([NamedConstructorArgument] string value);

        InheritedArgumentReturnType CreateWithDependencyAndInheritedArgument([NamedConstructorArgument(true)] string value);
    }
}