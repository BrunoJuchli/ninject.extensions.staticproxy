using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory;
using Xunit;

namespace Integration.Factory
{
    public class When_calling_factory_method_that_has_no_arguments
    {
        [Fact]
        public void It_should_return_created_type()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithoutArguments>().ToFactory();

            var expectedInstance = new NoArgumentsReturnType();
            kernel.Bind<NoArgumentsReturnType>().ToConstant(expectedInstance);

            var actualInstance = kernel
                .Get<IFactoryWithoutArguments>()
                .Create();

            actualInstance.Should().BeSameAs(expectedInstance);
        }

    }
}