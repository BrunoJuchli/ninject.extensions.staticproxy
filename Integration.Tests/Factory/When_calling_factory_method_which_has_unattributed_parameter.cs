using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory
{
    public class When_calling_factory_method_which_has_unattributed_parameter
    {
        [Fact]
        public void It_should_inject_parameter_as_typed_matching_argument()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithUnattributedArgument>().ToFactory();

            const string ExpectedValue = "AnyValue";

            var createdInstance = kernel
                .Get<IFactoryWithUnattributedArgument>()
                .Create(ExpectedValue);

            createdInstance.Value.Should().Be(ExpectedValue);
        }

        [Fact]
        public void It_should_not_inject_it_as_inherited_type_matching_argument()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithUnattributedArgument>().ToFactory();

            kernel
                .Get<IFactoryWithUnattributedArgument>()
                .Invoking(x => x.CreateWithDependencyArgument("AnyValue"))
                .ShouldThrow<ActivationException>();
        }
    }
}