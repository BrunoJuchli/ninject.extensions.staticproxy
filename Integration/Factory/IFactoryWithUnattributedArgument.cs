namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithUnattributedArgument
    {
        SingleArgumentReturnType Create(string notMatchingName);

        InheritedArgumentReturnType CreateWithDependencyArgument(string notMatchingName);
    }
}