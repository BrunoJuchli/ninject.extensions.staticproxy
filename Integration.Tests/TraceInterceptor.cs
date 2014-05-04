namespace Integration
{
    using System.Collections.Generic;

    public class TraceInterceptor : IDynamicInterceptor
    {
        private readonly ICollection<IDynamicInterceptor> interceptorCallLog;

        private readonly string name;

        public TraceInterceptor(ICollection<IDynamicInterceptor> interceptorCallLog, string name)
        {
            this.interceptorCallLog = interceptorCallLog;
            this.name = name;
        }

        public void Intercept(IInvocation invocation)
        {
            this.interceptorCallLog.Add(this);

            invocation.Proceed();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}