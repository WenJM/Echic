using System;
using System.Collections.Generic;
using System.Text;
using Echic.Domain.Data;
using Echic.Domain.IRepositories;

namespace Echic.Repository.UnitOfWork
{
    public interface IEfUnitOfWork : IUnitOfWorkRepositoryContext
    {
         BaseDbContext DBContext { get; }
    }
}
