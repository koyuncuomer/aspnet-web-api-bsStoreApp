﻿using System;
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
    public class BooksV2Controller : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksV2Controller(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync() 
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);
            var booksV2 = books.Select(b => new
            {
                Title = b.Title,
                Id = b.Id
            });
            return Ok(booksV2);
        }
    }
}
