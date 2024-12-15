﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String? Name { get; set; }

        public ICollection<Book> Books { get; set; } // Fiziksel olarak dbde karşılığı olmayacak ilişkiyi tanımlamak için gerekli
    }
}
