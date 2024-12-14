using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Username zorunlu alan.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password zorunlu alan.")]
        public string? Password { get; init; }
    }
}
