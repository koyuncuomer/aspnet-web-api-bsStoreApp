﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                .Include(b => b.Category)
                .FilterBooks(bookParameters.MinPrice, bookParameters.MaxPrice)
                .FilterByCategory(bookParameters.CategoryId)
                .Search(bookParameters.SearchTerm)
                .Sort(bookParameters.OrderBy)
                .ToListAsync();
            
            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }

        // BookController V2 versiyonu için hazırlanan sade metod
        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(b=>b.Id).ToListAsync();
        }

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges).Include(b => b.Category).SingleOrDefaultAsync();

        public void UpdateOneBook(Book book) => Update(book);
    }
}
