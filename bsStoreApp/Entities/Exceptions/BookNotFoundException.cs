﻿namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"{id} id'li kitap bulunamadı.")
        {
        }
    }
}

