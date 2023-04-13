using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, 
            ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _CategoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryWithProduct(int categoryId)
        {
            var Category = await _CategoryRepository.GetSingleCategoryByIdWithProductAsync(categoryId);
            var CategoryDto = _mapper.Map<CategoryWithProductsDto>(Category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, CategoryDto);
        }
    }
}
