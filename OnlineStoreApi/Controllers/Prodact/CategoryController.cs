using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.CustomServices;

namespace OnlineStoreApi.Controllers.Prodact
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICustomService<Category> _customService;

        public CategoryController(ICustomService<Category> customService)
        {
            _customService = customService;
        }

        [HttpGet(nameof(GetCategory))]
        public IActionResult GetCategory()
        {
            List<Category> Category = new List<Category>();
            Category = _customService.GetAll().ToList();
            if (Category is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Category);
            }
        }

        [HttpGet(nameof(GetProductById))]
        public IActionResult GetProductById(int id)
        {
            Category user = new Category();
            user = _customService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(nameof(PostInsertProduct))]
        public IActionResult PostInsertProduct(Category user)
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

        [HttpPost(nameof(PostDeleteProduct))]
        public IActionResult PostDeleteProduct(Category user)
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

        [HttpPost(nameof(PostUpdateProduct))]
        public IActionResult PostUpdateProduct(Category user)
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
