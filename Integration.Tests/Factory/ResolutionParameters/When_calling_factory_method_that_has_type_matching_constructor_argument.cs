using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory.ResolutionParameters
{
    public class When_calling_factory_method_that_has_type_matching_constructor_argument
    {
        [Fact]
        public void It_should_return_created_type()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithTypeMatchingConstructorArgument>().ToFactory();

            const string ExpectedValue = "AnyValue";

            var createdInstance = kernel
                .Get<IFactoryWithTypeMatchingConstructorArgument>()
                .Create(ExpectedValue);

            createdInstance.Value.Should().Be(ExpectedValue);
        }

        [Fact]
        public void When_has_dependency_and_argument_is_inherited_it_should_inject_it_in_dependencies()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithTypeMatchingConstructorArgument>().ToFactory();

            const string ExpectedValue = "AnyValue";

            var createdInstance = kernel
                .Get<IFactoryWithTypeMatchingConstructorArgument>()
                .CreateWithDependencyAndInheritedArgument(ExpectedValue);

            createdInstance.Dependency.Value.Should().Be(ExpectedValue);
        }

        [Fact]
        public void When_has_dependency_and_argument_is_not_inherited_it_should_throw()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithTypeMatchingConstructorArgument>().ToFactory();

            kernel
                .Get<IFactoryWithTypeMatchingConstructorArgument>()
                .Invoking(x => x.CreatedWithDependencyAndNotInheritedArgument("AnyValue"))
                .ShouldThrow<ActivationException>();
        }
    }
}