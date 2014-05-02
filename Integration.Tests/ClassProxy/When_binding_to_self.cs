namespace Integration.Tests.ClassProxy
{
    using Integration.ClassProxy;

    using Moq;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class When_binding_to_self
    {
        [Fact]
        public void Must_use_interceptor()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<InterceptedTarget>().ToSelf()
                    .Intercept(x => x
                        .By<ForwardToMockInterceptor>());

                kernel.Bind<ForwardToMockInterceptor>().ToSelf()
                    .InSingletonScope();

                Mock<IDynamicInterceptor> interceptorMock = kernel.Get<ForwardToMockInterceptor>().Mock;
                interceptorMock.Setup(x => x.Intercept(It.IsAny<IInvocation>()))
                    .Callback<IInvocation>(invocation => invocation.Proceed());
                var proxy = kernel.Get<InterceptedTarget>();

                proxy.Foo();

                interceptorMock.Verify(x => x.Intercept(It.Is<IInvocation>(invocation => invocation.Method.Name == "Foo")));
            }
        } 
    }
}