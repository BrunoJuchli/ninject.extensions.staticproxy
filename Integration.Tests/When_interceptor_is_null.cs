namespace Integration
{
    using System;

    using FluentAssertions;

    using Integration.ClassProxy;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Xunit;

    public class When_interceptor_is_null
    {
        [Fact]
        public void Binding_MustThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IInterceptedTarget>()
                    .ToSelf()
                    .Invoking(syntax => syntax.Intercept(x => x.By(null)))
                    .ShouldThrow<ArgumentNullException>();
            }
        } 
    }
}