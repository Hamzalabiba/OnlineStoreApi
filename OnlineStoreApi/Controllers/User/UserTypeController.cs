using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.CustomServices;

namespace OnlineStoreApi.Controllers.User
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly ICustomService<UserType> _customService;

        public UserTypeController(ICustomService<UserType> customService)
        {
            _customService = customService;
        }

        [HttpGet(nameof(GetUserType))]
        public IActionResult GetUserType()
        {
            List<UserType> UserType = new List<UserType>();
            UserType = _customService.GetAll().ToList();
            if (UserType is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(UserType);
            }
        }

        [HttpGet(nameof(GetUserById))]
        public IActionResult GetUserById(int id)
        {
            UserType user = new UserType();
            user = _customService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(nameof(PostInsertUser))]
        public IActionResult PostInsertUser(UserType user)
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
        public IActionResult PostDeleteUser(UserType user)
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
        public IActionResult PostUpdateUser(UserType user)
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