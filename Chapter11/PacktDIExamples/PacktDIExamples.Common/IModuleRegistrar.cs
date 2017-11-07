using Microsoft.Extensions.DependencyInjection;
using System;

namespace PacktDIExamples.Common
{
    public interface IModuleRegistrar
    {
        void Add(Type serviceType, Type implementationType, ServiceLifetime lifetime);
    }
}
