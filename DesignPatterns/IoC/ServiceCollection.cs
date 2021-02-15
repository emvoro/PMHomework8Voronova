using System;
using System.Collections.Generic;

namespace DesignPatterns.IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<Service> _services = new List<Service>();

        public IServiceCollection AddTransient<T>()
        {
            _services.Add(new Service(typeof(T), LifeTime.Transient));
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            _services.Add(new Service(typeof(T), factory as Func<IServiceProvider, IService>, LifeTime.Transient));
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            _services.Add(new Service(typeof(T), factory as Func<IServiceProvider, IService>, LifeTime.Transient));
            return this;
        }

        public IServiceCollection AddSingleton<T>()
        {
            _services.Add(new Service(typeof(T), LifeTime.Singleton));
            return this;
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            _services.Add(new Service(typeof(T), service));
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            _services.Add(new Service(typeof(T), factory as Func<IServiceProvider, IService>, LifeTime.Singleton));
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            _services.Add(new Service(typeof(T), factory as Func<IServiceProvider, IService>, LifeTime.Singleton));
            return this;
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_services);
        }
    }
}