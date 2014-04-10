namespace Integration.Tests
{
    using Moq;
    using Ninject;
    using Ninject.Extensions.StaticProxy;
    using Xunit;

    public class when_there_is_one_interceptor_for_proxy
    {
        [Fact]
        public void Must_use_interceptor()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IInterceptedTarget>().To<InterceptedTarget>()
                    .Intercept(x => x
                        .By<ForwardToMockInterceptor>());

                kernel.Bind<ForwardToMockInterceptor>().ToSelf()
                    .InSingletonScope();

                Mock<IDynamicInterceptor> interceptorMock = kernel.Get<ForwardToMockInterceptor>().Mock;
                interceptorMock.Setup(x => x.Intercept(It.IsAny<IInvocation>()))
                    .Callback<IInvocation>(invocation => invocation.Proceed());
                var proxy = kernel.Get<IInterceptedTarget>();

                proxy.Foo();

                interceptorMock.Verify(x => x.Intercept(It.Is<IInvocation>(invocation => invocation.Method.Name == "Foo")));
            }
        } 
    }
}