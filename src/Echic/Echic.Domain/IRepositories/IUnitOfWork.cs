using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Domain.IRepositories
{
    //工作单元基类接口
    public interface IUnitOfWork
    {
        bool IsCommitted { get; set; }

        int Commit();

        void Rollback();
    }
}
