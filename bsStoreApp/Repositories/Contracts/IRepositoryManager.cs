﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book {  get; }
        ICategoryRepository Category {  get; }
        IReviewRepository Review {  get; }
        Task SaveAsync();
    }
}
