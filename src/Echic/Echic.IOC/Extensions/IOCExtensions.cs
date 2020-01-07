using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Echic.Domain.Data;

namespace Echic.IOC
{
    public static class IOCExtensions
    {
        public static void UseMysSQLDB(this ContainerBuilder builder, string conn)
        {
            builder.Register(c => new MySqlDbContext(conn)).As<IDbContext>().InstancePerLifetimeScope();
        }
    }
}
