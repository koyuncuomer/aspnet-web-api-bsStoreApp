﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
    public record BookDtoForUpdate : BookDtoForManipulation
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int CategoryId { get; init; }
    }

}
