using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory
{
    public class When_calling_factory_method_that_has_name_matching_constructor_argument
    {
        [Fact]
        public void It_should_return_created_type()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithNameMatchingConstructorArgument>().ToFactory();

            const string ExpectedValue = "AnyValue";

            var createdInstance = kernel
                .Get<IFactoryWithNameMatchingConstructorArgument>()
                .Create(ExpectedValue);

            createdInstance.Value.Should().Be(ExpectedValue);
        }

        [Fact]
        public void When_argument_is_inherited_it_should_inject_it_in_dependencies()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithNameMatchingConstructorArgument>().ToFactory();

            const string ExpectedValue = "AnyValue";

            var createdInstance = kernel
                .Get<IFactoryWithNameMatchingConstructorArgument>()
                .CreateWithInheritedArgument(ExpectedValue);

            createdInstance.Dependency.Value.Should().Be(ExpectedValue);
        }

    }
}