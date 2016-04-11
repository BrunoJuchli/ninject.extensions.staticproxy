using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory
{
    public class When_calling_factory_method_that_returns_void
    {
        [Fact]
        public void It_should_throw()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IReturnVoidFactory>().ToFactory();

            var factory = kernel.Get<IReturnVoidFactory>();
            factory.Invoking(x => x.Create())
                .ShouldThrow<ActivationException>();
        }
    }
}