using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Echic.Domain.Model;

namespace Echic.Domain.Data
{
    public class MySqlDbContext : DbContext, IDbContext
    {
        private string DBConnetionString;

        public MySqlDbContext(string conn) : base()
        {
            this.DBConnetionString = conn;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ESUserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseMySQL(this.DBConnetionString);
        }
    }
}
