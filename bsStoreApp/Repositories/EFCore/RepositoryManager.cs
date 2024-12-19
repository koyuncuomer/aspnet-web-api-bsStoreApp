using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReviewRepository _reviewRepository;

        public RepositoryManager(RepositoryContext context, IBookRepository bookRepository, ICategoryRepository categoryRepository, IReviewRepository reviewRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _reviewRepository = reviewRepository;
        }

        public IBookRepository Book => _bookRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IReviewRepository Review => _reviewRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
