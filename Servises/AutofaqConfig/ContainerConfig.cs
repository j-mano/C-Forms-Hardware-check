using Autofac;
using Servises;
using Servises.Services.iServices;
using System.Linq;
using System.Reflection;

namespace Servises.AutofaqConfig
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Get_Cpu>().As<IGet_Cpu>();


            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Servises)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}