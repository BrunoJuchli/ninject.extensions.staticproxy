namespace Integration.Tests.InterfaceProxy
{
    using System;

    using FluentAssertions;

    using Integration.InterfaceProxy;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class When_there_is_no_proxy_implementation_for_interface
    {
        [Fact]
        public void Binding_MustThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Invoking(x => x.Bind<INoProxy>().ToProxy(p => { }))
                    .ShouldThrow<InvalidOperationException>()
                    .Where(ex => ex.Message.Contains("[StaticProxy]")); // or maybe we could introduce a custom exception so we don't have to check the message's to make sure it's actually the "right" error case.
            }
        } 
    }
}