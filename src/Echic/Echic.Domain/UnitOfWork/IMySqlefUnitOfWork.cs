using System;
using System.Collections.Generic;
using System.Text;
using Echic.Domain.Data;
using Echic.Domain.IRepositories;

namespace Echic.Domain.UnitOfWork
{
    public interface IMySqlefUnitOfWork : IUnitOfWorkRepositoryContext
    {
        IDbContext DBContext { get; }
    }
}
