using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICategoryService _categoryService;
        private readonly IReviewService _reviewService;

        public ServiceManager(IBookService bookService, IAuthenticationService authenticationService, ICategoryService categoryService, IReviewService reviewService)
        {
            _bookService = bookService;
            _authenticationService = authenticationService;
            _categoryService = categoryService;
            _reviewService = reviewService;
        }

        public IBookService BookService => _bookService;

        public IAuthenticationService AuthenticationService => _authenticationService;

        public ICategoryService CategoryService => _categoryService;

        public IReviewService ReviewService => _reviewService;
    }
}
