using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Echic.Common;
using Echic.Model.Config;
using Echic.Domain.Data;

namespace Echic.IOC
{
    public static class IOCExtensions
    {
        public static void UseMysSQLDB(this ContainerBuilder builder)
        {
            var dbCongif = ConfigBuilder.Configuration.GetEntity<ConnectionStrings>("ConnectionStrings");

            builder.RegisterType<MySqlDbContext>()
                .WithParameter("conn", dbCongif.EchicConnection)
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }

        public static void UseDomain(this ContainerBuilder builder)
        {
            var domainAssembly = Assembly.Load("Echic.Domain");

            builder.RegisterAssemblyTypes(domainAssembly)
                .Where(s => s.FullName.StartsWith("Echic.Domain.UnitOfWork"))
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            builder.RegisterAssemblyTypes(domainAssembly)
                .Where(s => s.FullName.StartsWith("Echic.Domain.Repositories"))
                .AsImplementedInterfaces()
                .PropertiesAutowired();
        }
    }
}
