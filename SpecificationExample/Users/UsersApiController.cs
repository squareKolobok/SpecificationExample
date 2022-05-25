using AutoFilterSpecification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecificationExample.Users.Database;
using SpecificationExample.Users.Models;

namespace SpecificationExample.Users
{
    [ApiController]
    [Route("/api/users")]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersApiController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, userRepository.GetUsers());
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search([FromBody] SearchUsersViewModel search)
        {
            var filter = new AutoFilter<SearchUsersViewModel>(search);
            var where = filter.GetFilter<User>();
            var users = userRepository.GetUsers(where);

            return StatusCode(StatusCodes.Status200OK, users);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] string userName)
        {
            var user = new User()
            {
                Name = userName
            };

            userRepository.AddUser(user);
            
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] string userName)
        {
            var user = new User()
            {
                Id = id,
                Name = userName
            };

            userRepository.ChangeUser(user);
            
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}