using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
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
            builder.UseMysSQLDB();
            //注册Domain
            builder.UseDomain();

            return builder;
        }

        public IServiceProvider InitServiceProvider(ContainerBuilder builder)
        {
            return new AutofacServiceProvider(Initialize().Build());
        }
    }
}
