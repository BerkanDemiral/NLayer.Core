using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetCategoryWithProduct(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetCategoryWithProduct(categoryId));
        }
    }
}
