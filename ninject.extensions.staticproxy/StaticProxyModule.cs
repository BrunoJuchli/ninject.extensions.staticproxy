namespace Ninject.Extensions.StaticProxy
{
    using Ninject.Modules;

    public class StaticProxyModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDynamicInterceptorManager>().To<DynamicInterceptorManager>();
            this.Bind<IDynamicInterceptorCollection>().ToProvider<DynamicInterceptorCollectionProvider>();

            this.Bind(typeof(DynamicInterceptorCollection<>)).ToSelf();
        }
    }
}