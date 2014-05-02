namespace Integration.Tests.InterfaceProxy
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Integration.ClassProxy;
    using Integration.InterfaceProxy;

    using Moq;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class When_there_are_multiple_interceptors
    {
        [Fact]
        public void Instanciating_ShouldNotThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IProxy>().ToProxy(x => x
                    .By(Mock.Of<IDynamicInterceptor>())
                    .By(Mock.Of<IDynamicInterceptor>()));

                kernel.Invoking(x => x.Get<IProxy>()).ShouldNotThrow();
            }
        }

        [Fact]
        public void MethodCall_MustUseInterceptorsInCorrectSequence()
        {
            var interceptionCallLog = new List<IDynamicInterceptor>();
            var interceptor1 = new TraceInterceptor(interceptionCallLog, "1");
            var interceptor2 = new TraceInterceptor(interceptionCallLog, "2");
            var interceptor3 = new TraceInterceptor(interceptionCallLog, "3");

            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IProxy>().ToProxy(x => x
                        .By(interceptor1, 10)
                        .By(interceptor2, 5)
                        .By(interceptor3, 15));

                var proxy = kernel.Get<IProxy>();

                proxy.Foo();
            }

            interceptionCallLog.Should()
                           .ContainInOrder(interceptor2, interceptor1, interceptor3)
                           .And.HaveCount(3);
        }
    }
}