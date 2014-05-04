namespace Integration.ClassProxy
{
    using Moq;

    public class ForwardToMockInterceptor : IDynamicInterceptor
    {
        public ForwardToMockInterceptor()
        {
            this.Mock = new Mock<IDynamicInterceptor>();
            this.Mock
                .Setup(x => x.Intercept(It.IsAny<IInvocation>()))
                .Callback<IInvocation>(invocation => invocation.Proceed());
        }

        public Mock<IDynamicInterceptor> Mock { get; private set; }

        public void Intercept(IInvocation invocation)
        {
            this.Mock.Object.Intercept(invocation);
        }
    }
}