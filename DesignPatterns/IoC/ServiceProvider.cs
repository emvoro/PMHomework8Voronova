using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.IoC
{
    public class ServiceProvider : IServiceProvider
    {
        private readonly List<Service> _services;

        public ServiceProvider(List<Service> services)
        {
            _services = services;
        }

        public T GetService<T>()
        {
            var service = _services.FirstOrDefault(x => x.Type == typeof(T));
            T instance;

            if (service == null)
                return default;

            else if (service.Instance != null)
                return (T)service.Instance;

            else
            {
                if (service.Factory != null)
                    instance = (T)service.Factory.DynamicInvoke();
                else
                {
                    var constructor = typeof(T).GetConstructors()[0];
                    instance = (T)constructor.Invoke(constructor.GetParameters()
                                             .Select(x => typeof(ServiceProvider)
                                             .GetMethod(nameof(GetService))?
                                             .MakeGenericMethod(x.ParameterType)
                                             .Invoke(this, null))
                                             .ToArray());
                }

                if (service.LifeTime == LifeTime.Singleton)
                    service.Instance = instance;
            }
            return instance;
        }
    }
}
