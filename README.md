[![Build status](https://ci.appveyor.com/api/projects/status/w4g31pqr4yi7i9ok)](https://ci.appveyor.com/project/BrunoJuchli/ninject-extensions-staticproxy)


![Icon](https://raw.github.com/BrunoJuchli/ninject.extensions.staticproxy/master/Icons/package_icon.png) Ninject.Extensions.StaticProxy
==============================

Proxying for platforms which don't support dynamic code emitting (Windows Store Applications, Xamarin.iOS...). Based on [StaticProxy.Fody](https://github.com/BrunoJuchli/StaticProxy.Fody/)

Features `.ToFactory()` binding for auto-implemented factories (as known from Ninject.Extensions.Factory) - see [Wiki](https://github.com/BrunoJuchli/ninject.extensions.staticproxy/wiki/Factory)

## Nuget

Nuget package http://nuget.org/packages/Ninject.Extensions.StaticProxy

To Install the static proxy weaver from the Nuget Package Manager Console 
    
    PM> Install-Package Ninject.Extensions.StaticProxy

## Usage

### Setup
 - install nuget package Ninject.Extensions.StaticProxy in the application project (composition root)
 - install nuget package StaticProxy.Fody in every project where types should be proxied
 - install nuget package StaticProxy.Interceptor in every project where you want to write interceptors.

### Configuring Class Proxy Interception
this is similar to castle dynamic proxy's "class proxy" and "interface proxy with target" proxy types.

 - put a `[StaticProxy]` attribute on the class
 - Write some interceptors (`FooInterceptor : IDynamicInterceptor`) - this is almost idential to Castle Dynamic Proxy Interceptors.
 - create / adjust the binding


        IBindingRoot.Bind<IFoo>().To<Foo>()
            .Intercept(x => x
                .By<LogInterceptor>()
                .By<ExceptionWrappingInterceptor>());
                

### Configuring Interface Proxy Interception
this is similar to castle dynamic proxy's "interface proxy without target" proxy type. Requires at least one interceptor!

 - put a `[StaticProxy]` attribute on the interface
 - Write some interceptors (`FooInterceptor : IDynamicInterceptor`) - this is almost idential to Castle Dynamic Proxy Interceptors.
 - create / adjust the binding


        IBindingRoot.Bind<IFoo>().ToProxy(x => x
                .By<FooImplementationInterceptor>();
                
 
## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)
