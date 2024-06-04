using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace start.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        ILogger<UsersController> logger;


        public CategoryController(ICategoryService categoryService, ILogger<UsersController> logger)
        {
            this.logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            try
            {
                var categories = await categoryService.Get();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                
                logger.LogError(ex, "Error occurred while fetching categories.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
