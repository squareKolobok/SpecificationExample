using Microsoft.AspNetCore.Mvc;
using SpecificationExample.Users.Database;

namespace SpecificationExample.Users
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View(userRepository.GetUsers());
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [Route("/users/{id:int}")]
        public IActionResult ChangeUser(int id)
        {
            return View(userRepository.GetUser(Specifications.ById(id)));
        }
    }
}
