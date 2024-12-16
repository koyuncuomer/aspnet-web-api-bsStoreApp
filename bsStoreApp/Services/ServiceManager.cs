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
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repositoryManager, 
            ILoggerService logger, 
            IMapper mapper, 
            UserManager<User> userManager,
            IConfiguration configuration,
            IBookLinks bookLinks)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));

            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper, bookLinks, _categoryService.Value));

            _authenticationService = new Lazy<IAuthenticationService>(() => 
            new AuthenticationManager(logger, mapper, userManager, configuration));
        }

        public IBookService BookService => _bookService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public ICategoryService CategoryService => _categoryService.Value;
    }
}
