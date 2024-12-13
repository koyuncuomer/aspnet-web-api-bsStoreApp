using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/books")]
    public class BookV2Controller : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BookV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync() 
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);
            return Ok(books);
        }
    }
}
