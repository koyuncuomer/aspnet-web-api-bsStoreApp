namespace Entities.DataTransferObjects
{
    public record BookDto()
    {
        public int Id { get; init; }
        public String Title { get; init; }
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
        public CategoryDto Category { get; init; }
    }
}
