namespace Integration.Tests
{
    public class FakeInterceptor : IDynamicInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            throw new System.NotImplementedException();
        }
    }
}