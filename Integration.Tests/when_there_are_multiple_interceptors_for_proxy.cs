namespace Integration.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Ninject;
    using Ninject.Extensions.StaticProxy;
    using Xunit;

    public class when_there_are_multiple_interceptors_for_proxy
    {
        [Fact]
        public void MustUseInterceptorsInCorrectOrder()
        {
            var interceptionCallLog = new List<IDynamicInterceptor>();
            var interceptor1 = new TraceInterceptor(interceptionCallLog);
            var interceptor2 = new TraceInterceptor(interceptionCallLog);
            var interceptor3 = new TraceInterceptor(interceptionCallLog);

            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IInterceptedTarget>().To<InterceptedTarget>()
                    .Intercept(x => x
                        .By(interceptor1, 10)
                        .By(interceptor2, 5)
                        .By(interceptor3, 15));

                var proxy = kernel.Get<IInterceptedTarget>();

                proxy.Foo();

                interceptionCallLog.Should()
                    .ContainInOrder(interceptor2, interceptor1, interceptor3)
                    .And.HaveCount(3);
            }
        }

        private class TraceInterceptor : IDynamicInterceptor
        {
            private readonly ICollection<IDynamicInterceptor> interceptorCallLog;

            public TraceInterceptor(ICollection<IDynamicInterceptor> interceptorCallLog)
            {
                this.interceptorCallLog = interceptorCallLog;
            }

            public void Intercept(IInvocation invocation)
            {
                this.interceptorCallLog.Add(this);

                invocation.Proceed();
            }
        }
    }
}