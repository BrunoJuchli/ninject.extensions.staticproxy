namespace Integration.InterfaceProxy
{
    using System.Reflection;

    using FluentAssertions;

    using Moq;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class When_there_is_one_interceptor
    {
        [Fact]
        public void Instanciating_ShouldNotThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IProxy>().ToProxy(x => x.By(Mock.Of<IDynamicInterceptor>()));

                kernel.Invoking(x => x.Get<IProxy>()).ShouldNotThrow();
            }
        }

        [Fact]
        public void MethodCall_MustUseInterceptor()
        {
            var interceptor = new Mock<IDynamicInterceptor>();
            MethodInfo expectedMethod = Reflector<IProxy>.GetMethod(x => x.Foo());

            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IProxy>().ToProxy(x => x.By(interceptor.Object));

                kernel.Get<IProxy>().Foo();
            }

            interceptor.Verify(x => x.Intercept(It.Is<IInvocation>(invocation => invocation.Method == expectedMethod)));
        }
    }
}