using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.CustomServices;
using Microsoft.AspNetCore.Http;

namespace OnlineStoreApi.Controllers.User
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICustomService<Users> _customService;

        public UserController(ICustomService<Users> customService)
        {
            _customService = customService;
        }

        [HttpGet(nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            List<Users> users = new List<Users>();
            users = _customService.GetAll().ToList();
            if (users is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(users);
            }
        }

        [HttpGet(nameof(GetUserById))]
        public IActionResult GetUserById(int id)
        {
            Users user = new Users();
            user = _customService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(nameof(PostInsertUser))]
        public IActionResult PostInsertUser(Users user)
        {
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                _customService.Insert(user);
                return Ok();
            }
        }

        [HttpPost(nameof(PostDeleteUser))]
        public IActionResult PostDeleteUser(Users user)
        {
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                _customService.Delete(user);
                return Ok();
            }
        }

        [HttpPost(nameof(PostUpdateUser))]
        public IActionResult PostUpdateUser(Users user)
        {
            if (user is null)
            {
                return NotFound();
            }
            else
            {
                _customService.Update(user);
                return Ok();
            }
        }
    }
}
