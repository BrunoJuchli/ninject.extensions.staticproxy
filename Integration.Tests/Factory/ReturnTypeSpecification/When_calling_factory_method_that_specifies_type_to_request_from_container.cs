using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory;
using Xunit;

namespace Integration.Factory.ReturnTypeSpecification
{
    public class When_calling_factory_method_that_specifies_type_to_request_from_container
    {
        [Fact]
        public void It_should_return_specified_type()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithReturnTypeSpecification>().ToFactory();

            kernel.Get<IFactoryWithReturnTypeSpecification>()
                .Create().Should().BeOfType<InterfaceReturnTypeImplementationBar>();
        }
    }
}