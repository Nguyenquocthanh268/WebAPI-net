using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Services;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;

        public ProductsController(IHangHoaRepository loaiRepository)
        {
            _hangHoaRepository = loaiRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(string search, double? from, double? to, string sortBy)
        {
            try
            {
                var result = _hangHoaRepository.GetAll(search, from, to, sortBy);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
    }
}
