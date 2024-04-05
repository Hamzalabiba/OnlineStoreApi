using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.CustomServices;
using Microsoft.AspNetCore.Http;

namespace OnlineStoreApi.Controllers
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
            List<Users>users = new List<Users>();
            users = _customService.GetAll().ToList();
            if (users is null) {
                 return NotFound();
            }
            else {
                return Ok(users);
            }
            
        }
    }
}
