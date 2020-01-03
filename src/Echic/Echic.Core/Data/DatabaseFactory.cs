using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Core.Data
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
