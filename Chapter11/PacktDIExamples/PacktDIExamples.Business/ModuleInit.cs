using Microsoft.Extensions.DependencyInjection;
using PacktDIExamples.Common;
using System.Composition;

namespace PacktDIExamples.Business
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Add(typeof(IUsersService), typeof(UsersService),
                ServiceLifetime.Transient);
        }
    }
}