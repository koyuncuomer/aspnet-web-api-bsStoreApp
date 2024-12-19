using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Review
{
    public abstract record ReviewDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public String Comment { get; init; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Range(1, 5)]
        public int Rating { get; init; }
    }
}
