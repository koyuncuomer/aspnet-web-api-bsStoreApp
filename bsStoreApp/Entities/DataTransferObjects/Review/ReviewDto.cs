using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Book;

namespace Entities.DataTransferObjects.Review
{
    public record ReviewDto
    {
        public int Id { get; init; }
        public int BookId { get; init; }
        public String UserId { get; init; }
        public string Comment { get; init; }
        public int Rating { get; init; }

        public BookDto Book { get; init; }
        public UserForMinimalDto User { get; init; }

    }
}
