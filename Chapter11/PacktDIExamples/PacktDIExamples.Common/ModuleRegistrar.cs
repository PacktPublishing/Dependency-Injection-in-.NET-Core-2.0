using Microsoft.Extensions.DependencyInjection;
using System;

namespace PacktDIExamples.Common
{
    internal class ModuleRegistrar : IModuleRegistrar
    {
        private readonly IServiceCollection _serviceCollection;
        public ModuleRegistrar(IServiceCollection serviceCollection)
        {
            this._serviceCollection = serviceCollection;
        }

        public void Add(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            this._serviceCollection.Add(descriptor);
        }
    }
}