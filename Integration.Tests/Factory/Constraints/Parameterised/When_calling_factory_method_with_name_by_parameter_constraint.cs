using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory.Constraints.Parameterised
{
    public class When_calling_factory_method_with_name_by_parameter_constraint
    {
        [Fact]
        public void It_should_use_named_binding()
        {
            const string Name = "AnyName";

            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithNamedByParameterConstraint>().ToFactory();

            kernel
                .Bind<IInterfaceReturnType>()
                .To<InterfaceReturnTypeImplementationFoo>()
                .Named(Name);

            kernel
                .Get<IFactoryWithNamedByParameterConstraint>()
                .CreateNamed(Name)
                .Should().BeOfType<InterfaceReturnTypeImplementationFoo>();
        }

        [Fact]
        public void When_name_is_not_bound_it_should_throw()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithNamedByParameterConstraint>().ToFactory();

            kernel
                .Get<IFactoryWithNamedByParameterConstraint>()
                .Invoking(x => x.CreateNamed("Not bound name"))
                .ShouldThrow<ActivationException>();
        }
    }
}