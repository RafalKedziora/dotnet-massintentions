using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [SwaggerOperation(Summary = "Retrieves all categories")]
        [HttpGet]
        public IActionResult Get()
        {
            var posts = _categoryService.GetAllCategories();
            return Ok(posts);
        }

        [SwaggerOperation(Summary ="Retrieves a specific category by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _categoryService.GetCategoryById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create a new category")]
        [HttpPost]
        public IActionResult Create(CreateCategoryDto newCategory)
        {
            var category = _categoryService.AddNewCategory(newCategory);
            return Created($"api/Categories/{category.Id}", category);
        }

        [SwaggerOperation(Summary = "Update an existing category")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryDto updateCategory)
        {
            _categoryService.UpdateCategory(id, updateCategory);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific category")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
