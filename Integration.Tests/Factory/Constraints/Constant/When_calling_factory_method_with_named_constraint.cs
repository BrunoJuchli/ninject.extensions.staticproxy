using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory.Constraints.Constant
{
    public class When_calling_factory_method_with_named_constraint
    {
        [Fact]
        public void It_should_use_named_binding()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithNamedConstraint>().ToFactory();

            kernel
                .Bind<IInterfaceReturnType>()
                .To<InterfaceReturnTypeImplementationBar>()
                .Named(Constants.Bar);

            kernel
                .Get<IFactoryWithNamedConstraint>()
                .CreateBar()
                .Should().BeOfType<InterfaceReturnTypeImplementationBar>();
        }

        [Fact]
        public void When_name_is_not_bound_it_should_throw()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithNamedConstraint>().ToFactory();

            kernel
                .Get<IFactoryWithNamedConstraint>()
                .Invoking(x => x.CreateBar())
                .ShouldThrow<ActivationException>();
        }
    }
}