using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record UserForMinimalDto
    {
        public string Id { get; init; }
        public string Username { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string Email { get; init; }
    }
}
