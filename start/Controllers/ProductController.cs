using AutoMapper;
using Entities;
using Entities.DtoPtoduct;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace start.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        IMapper mapper;
        IProductService productService;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(string? desc, int? minPrice, int? maxPrice,[FromQuery] int?[] categoryIds, int position=1, int skip=20)
        {

            List<Product> products = await productService.Get(position, skip, desc, minPrice, maxPrice, categoryIds);

            List<ProductDto> productsDto = mapper.Map<List<ProductDto>>(products);
            if (productsDto != null)
                return Ok(productsDto);
            return BadRequest();
        }
    }
}
