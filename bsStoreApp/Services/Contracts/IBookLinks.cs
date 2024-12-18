using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Book;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;

namespace Services.Contracts
{
    public interface IBookLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto, string fields, HttpContext httpContext);
    }
}
