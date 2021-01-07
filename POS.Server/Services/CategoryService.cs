using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using POS.Contracts;
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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public override async Task<Empty> AddCategory(CategoryModel request, ServerCallContext context)
        {
            await _unitOfWork.CategoryRepo.Insert(new Domain.Models.ItemCategory
            {
                Description = request.Description,
                Name = request.Name
            });
            await _unitOfWork.SaveAsync();
            return await Task.FromResult(new Empty());
        }

        public override async Task<Empty> DeleteCategory(CategoryModel request, ServerCallContext context)
        {
            await _unitOfWork.CategoryRepo.DeleteAsync(request.Description);
            await _unitOfWork.SaveAsync();
            return await Task.FromResult(new Empty());
        }

        public override async Task<CategoryModel> GetCategory(CategoryModel request, ServerCallContext context)
        {
          var results = await  _unitOfWork.CategoryRepo.GetByID(new Guid(request.Id));
            return new CategoryModel
            {
                Id = results.CategoryId.ToString(),
                Name = results.Name,
                Description = results.Description
            };
        }

        public override async Task<Empty> UpdateCategory(CategoryModel request, ServerCallContext context)
        {
            _unitOfWork.CategoryRepo.Update(new Domain.Models.ItemCategory { 
             CategoryId = new Guid(request.Id), Name = request.Name, Description = request.Description
            });
            await _unitOfWork.SaveAsync();
            return await Task.FromResult(new Empty());

        }
        public override Task<Categories> GetAllCategories(Empty request, ServerCallContext context)
        {
            return (Task<Categories>)_unitOfWork.CategoryRepo.Get().Cast<Categories>();
        }
    }
}
