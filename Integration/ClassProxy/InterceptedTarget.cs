namespace Integration.ClassProxy
{
    [StaticProxy]
    public class InterceptedTarget : IInterceptedTarget
    {
        public int FooReturnValue { get; set; }

        public int Foo()
        {
            return this.FooReturnValue;
        }

        public void Bar()
        {  
        }
    }
}