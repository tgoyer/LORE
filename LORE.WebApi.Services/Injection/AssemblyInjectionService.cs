using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace LORE.WebApi.Services.Injection
{
    public class AssemblyInjectionService : DefaultAssembliesResolver
    {
        readonly List<Assembly> assemblies = new List<Assembly>();
        private AssemblyInjectionService()
        {
            assemblies.AddRange(base.GetAssemblies());
        }

        public static AssemblyInjectionService Initialize()
        {
            return new AssemblyInjectionService();
        }

        public AssemblyInjectionService RegisterAssembly(Assembly assembly)
        {
            if (assembly != null && !assemblies.Contains(assembly)) // Don't inject more than once.
                assemblies.Add(assembly);
            return this;
        }

        public AssemblyInjectionService RegisterAssembly(string path)
        {
            return RegisterAssembly(Assembly.LoadFrom(path));
        }

        public AssemblyInjectionService RegisterAssembly(Type type)
        {
            return RegisterAssembly(type.Assembly);
        }

        public override ICollection<Assembly> GetAssemblies()
        {
            return assemblies;
        }
    }
}
