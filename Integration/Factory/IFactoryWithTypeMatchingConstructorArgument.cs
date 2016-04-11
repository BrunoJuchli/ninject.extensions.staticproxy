using Ninject.Extensions.StaticProxy.Factory;

namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithTypeMatchingConstructorArgument
    {
        SingleArgumentReturnType Create([TypeMatchingConstructorArgument] string notMatchingName);

        InheritedArgumentReturnType CreatedWithDependencyAndNotInheritedArgument([TypeMatchingConstructorArgument] string notMatchingName);

        InheritedArgumentReturnType CreateWithDependencyAndInheritedArgument([TypeMatchingConstructorArgument(true)] string notMatchingName);
    }
}