using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Category;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize]
        [HttpHead]
        [HttpGet(Name = "GetAllCategoriesAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] CategoryParameters categoryParameters)
        {
            return Ok(await _manager.CategoryService.GetAllCategoriesAsync(categoryParameters, false));
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryByIdAsync([FromRoute] int id)
        {
            return Ok(await _manager.CategoryService.GetOneCategoryByIdAsync(id, false));
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneCategoryAsync")]
        public async Task<IActionResult> CreateOneCategoryAsync([FromBody] CategoryDtoForInsertion categoryDto)
        {
            var category = await _manager.CategoryService.CreateOneCategoryAsync(categoryDto);
            return StatusCode(201, category);
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategoryAsync([FromRoute(Name = "id")] int id, [FromBody] CategoryDtoForUpdate categoryDto)
        {
            if (categoryDto.Id != id)
                return BadRequest();

            await _manager.CategoryService.UpdateOneCategoryAsync(id, categoryDto, false);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategoryAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.CategoryService.DeleteOneCategoryAsync(id, false);
            return NoContent();
        }

        [Authorize]
        [HttpOptions]
        public IActionResult GetCategoryOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, HEAD, OPTIONS");
            return Ok();
        }
    }
}
