namespace ManualNugetIntegrationTest
{
    using System;

    public class FakeInterceptor : IDynamicInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("intercepting. Before {0}", invocation.Method.Name);
            
            invocation.Proceed();

            Console.WriteLine("intercepting. After {0}", invocation.Method.Name);
        }
    }
}