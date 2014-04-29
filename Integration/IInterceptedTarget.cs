namespace Integration
{
    public interface IInterceptedTarget
    {
        int FooReturnValue { get; set; }

        int Foo();

        void Bar();
    }
}