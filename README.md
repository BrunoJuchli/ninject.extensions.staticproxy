[![Build status](https://ci.appveyor.com/api/projects/status/w4g31pqr4yi7i9ok)](https://ci.appveyor.com/project/BrunoJuchli/ninject-extensions-staticproxy)


![Icon](https://raw.github.com/BrunoJuchli/StaticProxy/master/Icons/package_icon.png) Ninject.Extensions.StaticProxy
==============================

Proxying for platforms which don't support dynamic code emitting (WinRT, Windows Phone, IPhone...). Based on [StaticProxy.Fody](https://github.com/BrunoJuchli/StaticProxy.Fody/)

Future Features:
 - `.ToFactory()` binding for auto-implemented factories (as known from Ninject.Extensions.Factory).

## Nuget

Nuget package http://nuget.org/packages/Ninject.Extensions.StaticProxy

To Install the static proxy weaver from the Nuget Package Manager Console 
    
    PM> Install-Package Ninject.Extensions.StaticProxy

## Usage

### Setup
 - install the nuget package
 - install StaticProxy.Fody in every project where types should be proxied
 - install StaticProxy.Interceptor in every project where you want to write interceptors.

### Configuring Interception

 - put a `[StaticProxy]` attribute on the class 
 - Write some interceptors (`FooInterceptor : IDynamicInterceptor`) - this is almost idential to Castle Dynamic Proxy Interceptors.
 - create / adjust the binding


        IBindingRoot.Bind<IFoo>().To<Foo>()
            .Intercept(x => x
                .By<LogInterceptor>()
                .By<ExceptionWrappingInterceptor>());
 
## Icon

Icon courtesy of [The Noun Project](http://thenounproject.com)
