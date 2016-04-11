namespace Integration.Factory
{
    [StaticProxy]
    public interface IFactoryWithUninterpretedArgument
    {
        NoArgumentsReturnType Create(string doesntMatter);
    }
}