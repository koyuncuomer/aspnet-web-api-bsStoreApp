﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Kitap 1", Price = 110 },
                new Book { Id = 2, Title = "Kitap 2", Price = 220 },
                new Book { Id = 3, Title = "Kitap 3", Price = 330 }
            );
        }
    }
}