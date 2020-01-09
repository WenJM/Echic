using System;
using System.Collections.Generic;
using System.Text;
using Echic.Domain.Model;
using Echic.Domain.IRepositories;

namespace Echic.Repository.Repositories
{
    public class UserRepository : EfBaseRepository<ES_User>, IUserRepository
    {
        public void CreateUser(ES_User user)
        {
            this.Add(user);
        }

        public bool DeleteUser(ES_User user)
        {
            var obj = this.GetById(user.ObjectID);

            return this.Delete(obj) > 0;
        }

        public ES_User GetUserByID(string userid)
        {
            return this.GetById(userid);
        }

        public ES_User GetUserByName(string username)
        {
            return this.Get(s => s.Username == username);
        }
    }
}
