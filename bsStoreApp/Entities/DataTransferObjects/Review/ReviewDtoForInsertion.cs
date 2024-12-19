using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Review
{
    public record ReviewDtoForInsertion : ReviewDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int BookId { get; init; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public String UserId { get; init; }
    }
}
