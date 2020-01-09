using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Echic.Domain.Model;
using Echic.Domain.IRepositories;

namespace Echic.Test.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public HomeController(IUserRepository repository)
        {
            this.UserRepository = repository;
        }

        public IActionResult Index()
        {
            try
            {
                var id = Guid.NewGuid();
                var user = new ES_User()
                {
                    ObjectID = id.ToString(),
                    Username = "Administrator",
                    Password = "123456",
                    Expired = DateTime.Now.AddYears(120),
                    CreatedBy = id.ToString(),
                    CreatedTime = DateTime.Now
                };

                this.UserRepository.CreateUser(user);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }
    }
}