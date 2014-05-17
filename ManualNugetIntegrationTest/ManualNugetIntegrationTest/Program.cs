namespace ManualNugetIntegrationTest
{
    using System;

    using Microsoft.Practices.Unity;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Unity.StaticProxyExtension;

    class Program
    {
        static void Main(string[] args)
        {
            TestNinject();

            TestUnity();

            Console.ReadKey();
        }

        private static void TestNinject()
        {
            Console.WriteLine("ninject");

            var kernel = new StandardKernel();

            kernel.Bind<Proxied>().ToSelf()
                .Intercept(x => x.By<FakeInterceptor>());

            var instance = kernel.Get<Proxied>();

            instance.Foo();
        }

        private static void TestUnity()
        {
            Console.WriteLine();
            Console.WriteLine("unity");

            var container = new UnityContainer();
            container.AddNewExtension<StaticProxyExtension>();

            container.RegisterType<Proxied, Proxied>(new Intercept<FakeInterceptor>());

            var instance = container.Resolve<Proxied>();

            instance.Foo();
        }
    }
}
