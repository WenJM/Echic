using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Echic.Core.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() { }

        public BaseDbContext(DbContextOptions<BaseDbContext> Options) : base(Options)
        {

        }
    }
}
