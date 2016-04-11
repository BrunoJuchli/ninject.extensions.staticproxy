using FluentAssertions;
using Ninject;
using Ninject.Extensions.StaticProxy.Factory.Resolution;
using System;
using Xunit;

namespace Integration.Factory
{
    public class When_binding_class_to_proxy
    {
        [Fact]
        public void Binding_must_throw()
        {
            var kernel = new StandardKernel();
            kernel
                .Bind<FooClass>()
                .Invoking(x => x.ToFactory())
                .ShouldThrow<NotSupportedException>();
        }

        public class FooClass
        {
        }
    }
}