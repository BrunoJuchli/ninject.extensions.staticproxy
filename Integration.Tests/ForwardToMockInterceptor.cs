namespace Integration.Tests
{
    using Moq;

    public class ForwardToMockInterceptor : IDynamicInterceptor
    {
        public ForwardToMockInterceptor()
        {
            this.Mock = new Mock<IDynamicInterceptor>();
        }

        public Mock<IDynamicInterceptor> Mock { get; private set; }

        public void Intercept(IInvocation invocation)
        {
            this.Mock.Object.Intercept(invocation);
        }
    }
}