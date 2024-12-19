using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Review;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ReviewsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize]
        [HttpHead]
        [HttpGet(Name = "GetAllReviewsAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllReviewsAsync([FromQuery] ReviewParameters reviewParameters)
        {
            var result = await _manager.ReviewService.GetAllReviewsAsync(reviewParameters, false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));

            return Ok(result.reviews);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneReviewAsync([FromRoute(Name = "id")] int id)
        {
            var review = await _manager.ReviewService.GetOneReviewByIdAsync(id, false);
            return Ok(review);
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneReviewAsync")]
        public async Task<IActionResult> CreateOneReviewAsync([FromBody] ReviewDtoForInsertion reviewDto)
        {
            var review = await _manager.ReviewService.CreateOneReviewAsync(reviewDto);
            return StatusCode(201, review);
        }

        [Authorize(Roles = "Editor, Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneReviewAsync([FromRoute(Name = "id")] int id, [FromBody] ReviewDtoForUpdate reviewDto)
        {
            if (reviewDto.Id != id)
                return BadRequest();

            await _manager.ReviewService.UpdateOneReviewAsync(id, reviewDto, false);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneReviewAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.ReviewService.DeleteOneReviewAsync(id, false);
            return NoContent();
        }

        [Authorize]
        [HttpOptions]
        public IActionResult GetReviewOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, HEAD, OPTIONS");
            return Ok();
        }

    }
}
