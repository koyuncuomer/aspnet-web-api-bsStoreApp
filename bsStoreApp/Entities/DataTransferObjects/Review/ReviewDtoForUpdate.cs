using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Review
{
    public record ReviewDtoForUpdate : ReviewDtoForManipulation
    {
        [Required]
        public int Id { get; init; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int BookId { get; init; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public String UserId { get; init; }
    }
}
