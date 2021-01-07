using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace POS.Client
{
    public class DependencyContainer
    {
        public static ILifetimeScope Container { get; set; }
        static DependencyContainer()
        {
            if (Container == null) Container = BuildContainer();
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
           
            // Scan an assembly for components
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.Name.EndsWith("ViewModel"))
                   .AsSelf();

            var container = builder.Build();
            return container;
        }

    }
}
