namespace Integration.InterfaceProxy
{
    using System;

    using FluentAssertions;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class When_there_is_no_interceptor
    {
        [Fact]
        public void Instanciating_MustThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IProxy>().ToProxy(x => { });

                kernel.Invoking(x => x.Get<IProxy>())
                    .ShouldThrow<InvalidOperationException>();
            }
        }
    }
}