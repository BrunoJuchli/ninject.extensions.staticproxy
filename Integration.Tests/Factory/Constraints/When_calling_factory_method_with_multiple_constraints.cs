using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Xunit;

namespace Integration.Factory.Constraints
{
    public class When_calling_factory_method_with_multiple_constraints
    {
        [Fact]
        public void It_should_resolve_binding_which_matches_all_constraints()
        {
            const string Name = "AnyName";

            var kernel = new StandardKernel();

            // matching name
            kernel
                .Bind<IInterfaceReturnType>()
                .To<InterfaceReturnTypeImplementationBar>()
                .Named(Name);

            // matching metadata key
            kernel
                .Bind<IInterfaceReturnType>()
                .To<InterfaceReturnTypeImplementationBar>()
                .WithMetadata(Constants.Foo, "AnyMetadata");

            // matching name & metadata
            var matchingAllConstraintsInstance = new InterfaceReturnTypeImplementationFoo();
            kernel
                .Bind<IInterfaceReturnType>()
                .ToConstant(matchingAllConstraintsInstance)
                .Named(Name)
                .WithMetadata(Constants.Foo, "AnyMetadata");

            kernel.Bind<IFactoryWithMultipleConstraints>().ToFactory();

            kernel
                .Get<IFactoryWithMultipleConstraints>()
                .Create(Name)
                .Should().BeSameAs(matchingAllConstraintsInstance);
        }
    }
}