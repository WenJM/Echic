using System;
using System.Collections.Generic;
using System.Text;
using Echic.Domain.Model;

namespace Echic.Domain.IRepositories
{
    public interface IUserRepository
    {
        ES_User GetUserByName(string username);

        ES_User GetUserByID(string userid);

        void CreateUser(ES_User user);
    }
}
