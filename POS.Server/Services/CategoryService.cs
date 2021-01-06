using Grpc.Core;
using Microsoft.Extensions.Logging;
using POSBeta.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Server
{
    public class CategoryService : Category.CategoryBase
    {
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ILogger<CategoryService> logger)
        {
            _logger = logger;
        }

        public override Task<CategoryModel> AddCategory(CategoryModel request, ServerCallContext context)
        {
            return Task.FromResult(new CategoryModel
            {
                Name = request.Name
            });
        }
    }
}
