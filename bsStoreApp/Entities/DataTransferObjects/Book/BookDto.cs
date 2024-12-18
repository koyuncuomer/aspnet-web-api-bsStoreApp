using Entities.DataTransferObjects.Category;

namespace Entities.DataTransferObjects.Book
{
    public record BookDto()
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
        public CategoryDto Category { get; init; }
    }
}
