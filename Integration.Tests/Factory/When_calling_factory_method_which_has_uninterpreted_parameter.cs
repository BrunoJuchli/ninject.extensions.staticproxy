using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using System;
using Xunit;

namespace Integration.Factory
{
    public class When_calling_factory_method_which_has_uninterpreted_parameter
    {
        [Fact]
        public void It_should_throw()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFactoryWithUninterpretedArgument>().ToFactory();

            kernel
                .Get<IFactoryWithUninterpretedArgument>()
                .Invoking(x => x.Create("anyValue"))
                .ShouldThrow<Exception>(); // todo define what kind of exception
        }
    }
}