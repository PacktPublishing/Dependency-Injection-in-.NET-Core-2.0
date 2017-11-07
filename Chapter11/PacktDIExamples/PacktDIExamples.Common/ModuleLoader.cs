using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace PacktDIExamples.Common
{
    public static class ModuleLoader
    {
        public static void LoadContainer(IServiceCollection collection, string pattern)
        {
            try
            {
                var executableLocation = Assembly.GetEntryAssembly().Location;

                var assemblies = Directory
                            .GetFiles(Path.GetDirectoryName(executableLocation), pattern, SearchOption.AllDirectories)
                            .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                            .ToList();
                var configuration = new ContainerConfiguration()
                    .WithAssemblies(assemblies);
                using (var container = configuration.CreateContainer())
                {
                    IEnumerable<IModule> modules = container.GetExports<IModule>();

                    var registrar = new ModuleRegistrar(collection);
                    foreach (IModule module in modules)
                    {
                        module.Initialize(registrar);
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }
                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }
    }
}