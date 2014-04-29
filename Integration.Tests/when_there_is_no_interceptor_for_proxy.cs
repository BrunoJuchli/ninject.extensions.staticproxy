namespace Integration.Tests
{
    using FluentAssertions;
    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class when_there_is_no_interceptor_for_proxy
    {
        [Fact]
        public void Must_execute_original_method()
        {
            const int ExpectedValue = 583;

            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IInterceptedTarget>().To<InterceptedTarget>()
                    .Intercept(x => { });

                var proxy = kernel.Get<IInterceptedTarget>();

                proxy.FooReturnValue = ExpectedValue;

                int actualValue = proxy.Foo();

                actualValue.Should().Be(ExpectedValue);
            }
        } 
    }
}
