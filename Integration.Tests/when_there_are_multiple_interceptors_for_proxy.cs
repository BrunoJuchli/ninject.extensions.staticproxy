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
            var interceptor1 = new TraceInterceptor(interceptionCallLog, "1");
            var interceptor2 = new TraceInterceptor(interceptionCallLog, "2");
            var interceptor3 = new TraceInterceptor(interceptionCallLog, "3");

            using (var kernel = new StandardKernel())
            {
                kernel.Bind<InterceptedTarget>().ToSelf()
                    .Intercept(x => x
                        .By(interceptor1, 10)
                        .By(interceptor2, 5)
                        .By(interceptor3, 15));

                var proxy = kernel.Get<InterceptedTarget>();

                proxy.Bar();

                interceptionCallLog.Should()
                    .ContainInOrder(interceptor2, interceptor1, interceptor3)
                    .And.HaveCount(3);
            }
        }

        private class TraceInterceptor : IDynamicInterceptor
        {
            private readonly ICollection<IDynamicInterceptor> interceptorCallLog;

            private readonly string name;

            public TraceInterceptor(ICollection<IDynamicInterceptor> interceptorCallLog, string name)
            {
                this.interceptorCallLog = interceptorCallLog;
                this.name = name;
            }

            public void Intercept(IInvocation invocation)
            {
                this.interceptorCallLog.Add(this);

                invocation.Proceed();
            }

            public override string ToString()
            {
                return this.name;
            }
        }
    }
}