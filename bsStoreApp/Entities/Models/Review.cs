﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; } 
        public Book Book { get; set; } 

        public String UserId { get; set; } 
        public User User { get; set; } 

        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
