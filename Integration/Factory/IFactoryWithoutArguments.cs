namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithoutArguments
    {
        NoArgumentsReturnType Create();
    }
}