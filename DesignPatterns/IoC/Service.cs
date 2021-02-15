using System;

namespace DesignPatterns.IoC
{
    public class Service : IService
    {
        public LifeTime LifeTime { get; }

        public Type Type { get; }

        public object Instance { get; internal set; }

        public Func<IServiceProvider, IService> Factory { get; internal set; }

        public Service(Type type, LifeTime lifeTime)
        {
            LifeTime = lifeTime;
            Type = type;
        }

        public Service(Type type, object instance) : this(type, LifeTime.Singleton)
        {
            Instance = instance;
        }

        public Service(Type type, Func<IServiceProvider, IService> factory, LifeTime lifetime) : this(type, lifetime)
        {
            Factory = factory;
        }
    }
}
