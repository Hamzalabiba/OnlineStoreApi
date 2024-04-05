using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities;
using OnlineStore.Service.CustomServices;

namespace OnlineStoreApi.Controllers.Prodact
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ICustomService<Products> _customService;

        public ProductController(ICustomService<Products> customService)
        {
            _customService = customService;
        }

        [HttpGet(nameof(GetProducts))]
        public IActionResult GetProducts()
        {
            List<Products> Products = new List<Products>();
            Products = _customService.GetAll().ToList();
            if (Products is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Products);
            }
        }

        [HttpGet(nameof(GetProductById))]
        public IActionResult GetProductById(int id)
        {
            Products user = new Products();
            user = _customService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost(nameof(PostInsertProduct))]
        public IActionResult PostInsertProduct(Products user)
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
        public IActionResult PostDeleteProduct(Products user)
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
        public IActionResult PostUpdateProduct(Products user)
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
