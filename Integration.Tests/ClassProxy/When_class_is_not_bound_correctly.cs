namespace Integration.Tests.ClassProxy
{
    using System;

    using FluentAssertions;

    using Integration.ClassProxy;

    using Ninject;

    using Xunit;

    public class When_class_is_not_bound_correctly
    {
        [Fact]
        public void BoundWithInterface_InstanciateMustThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IInterceptedTarget>().To<InterceptedTarget>();

                kernel.Invoking(x => x.Get<IInterceptedTarget>())
                    .ShouldThrow<InvalidOperationException>();
            }
        }

        [Fact]
        public void BoundToSelf_InstanciateMustThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<InterceptedTarget>().ToSelf();

                kernel.Invoking(x => x.Get<InterceptedTarget>())
                    .ShouldThrow<InvalidOperationException>();
            }
        }

        [Fact]
        public void DefaultBinding_InstanciateMustThrow()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Invoking(x => x.Get<InterceptedTarget>())
                    .ShouldThrow<InvalidOperationException>();
            }
        }
    }
}