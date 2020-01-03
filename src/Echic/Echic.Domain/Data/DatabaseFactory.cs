using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Domain.Data
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private BaseDbContext dataContext;

        public BaseDbContext Get()
        {
            return dataContext ?? (dataContext = new BaseDbContext());
        }
    }
}
