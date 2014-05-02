namespace ManualNugetIntegrationTest
{
    using System;

    [StaticProxy]
    public class Proxied
    {
        public void Foo()
        {
            Console.WriteLine("inside original implementation of Proxied.Foo()");
        }
    }
}