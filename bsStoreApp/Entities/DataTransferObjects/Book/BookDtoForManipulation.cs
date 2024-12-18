using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter içermelidir.")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir.")]
        public String Title { get; init; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Range(10, 1000)]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Bu alan zorunludur.aaaaaaa")]
        public String Author { get; init; }
    }
}
