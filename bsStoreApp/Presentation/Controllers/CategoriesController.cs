using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] CategoryParameters categoryParameters)
        {
            return Ok(await _manager.CategoryService.GetAllCategoriesAsync(categoryParameters, false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryByIdAsync([FromRoute] int id)
        {
            return Ok(await _manager.CategoryService.GetOneCategoryByIdAsync(id, false));
        }
    }
}
