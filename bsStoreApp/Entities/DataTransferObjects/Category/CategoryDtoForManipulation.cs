using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Category
{
    public abstract record CategoryDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir.")]
        public string Name { get; init; }

    }
}
