using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Echic.Common;
using Echic.Model.Config;

namespace Echic.IOC
{
    public class IOCBuilder
    {
        public static ContainerBuilder Initialize()
        {
            var builder = new ContainerBuilder();

            //注册MySqlDB
            var dbCongif = ConfigBuilder.Configuration.GetEntity<ConnectionStrings>("ConnectionStrings");
            builder.UseMysSQLDB(dbCongif.EchicConnection);

            return builder;
        }

        public IServiceProvider InitServiceProvider(ContainerBuilder builder)
        {
            return new AutofacServiceProvider(Initialize().Build());
        }
    }
}
