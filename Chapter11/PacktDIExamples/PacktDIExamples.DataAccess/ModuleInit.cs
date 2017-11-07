using Microsoft.Extensions.DependencyInjection;
using PacktDIExamples.Common;
using System.Composition;

namespace PacktDIExamples.DataAccess
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.Add(typeof(IUsersRepository), typeof(UsersRepository),
                ServiceLifetime.Transient);
        }
    }
}
