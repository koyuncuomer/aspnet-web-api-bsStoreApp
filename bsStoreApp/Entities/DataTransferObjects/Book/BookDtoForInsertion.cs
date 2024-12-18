using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Book
{
    public record BookDtoForInsertion : BookDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int CategoryId { get; init; }
    }

}
