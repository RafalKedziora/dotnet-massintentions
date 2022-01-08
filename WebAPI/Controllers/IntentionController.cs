using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntentionController : ControllerBase
    {
        private readonly IIntentionService _intentionService;
        public IntentionController(IIntentionService intentionService)
        {
            _intentionService = intentionService;
        }

        [SwaggerOperation(Summary = "Retrieves all intentions")]
        [HttpGet]
        public IActionResult Get()
        {
            var intentions = _intentionService.GetAllIntentions();
            return Ok(intentions);
        }

        [SwaggerOperation(Summary = "Retrieves a specific intention by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var intention = _intentionService.GetIntentionById(id);
            if(intention == null)
            {
                return NotFound();
            }
            return Ok(intention);
        }

        [SwaggerOperation(Summary = "Retrieves all intentions in a specific date")]
        [HttpGet("{date}")]
        public IActionResult Get(DateTime date)
        {
            var intentions = _intentionService.GetIntentionsByDate(date);
            if (intentions == null)
            {
                return NotFound();
            }
            return Ok(intentions);
        }

        [SwaggerOperation(Summary = "Create a new intention")]
        [HttpPost]
        public IActionResult Create(CreateIntentionDto newIntention)
        {
            var intention = _intentionService.AddNewIntention(newIntention);
            return Created($"api/intentions/{intention.Id}", intention);
        }

        [SwaggerOperation(Summary = "Update an existing intention")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateIntentionDto updateIntention)
        {
            _intentionService.UpdateIntention(id, updateIntention);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific intention")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _intentionService.DeleteIntention(id);
            return NoContent();
        }
    }
}
