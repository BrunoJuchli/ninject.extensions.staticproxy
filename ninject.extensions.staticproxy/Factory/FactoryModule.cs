using Ninject.Extensions.StaticProxy.Factory.Resolution;
using Ninject.Modules;

namespace Ninject.Extensions.StaticProxy.Factory
{
    public class FactoryModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAttributesInterpreter>().To<AttributesInterpreter>();
            this.Bind<IInstanceResolver>().To<InstanceResolver>();
        }
    }
}