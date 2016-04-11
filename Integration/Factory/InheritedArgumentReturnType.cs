namespace Integration.Factory
{
    public class InheritedArgumentReturnType
    {
        public InheritedArgumentReturnType(SingleArgumentReturnType dependency)
        {
            Dependency = dependency;
        }

        public SingleArgumentReturnType Dependency { get; }
    }
}