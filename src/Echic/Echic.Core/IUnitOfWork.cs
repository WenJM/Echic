using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        void CommitAsync();
    }
}
