using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Category
{
    public record CategoryDtoForUpdate : CategoryDtoForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
}
