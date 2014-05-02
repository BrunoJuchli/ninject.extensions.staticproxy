namespace ManualNugetIntegrationTest
{
    using System;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind<Proxied>().ToSelf()
                .Intercept(x => x.By<FakeInterceptor>());

            var instance = kernel.Get<Proxied>();

            instance.Foo();

            Console.ReadKey();
        }
    }
}
