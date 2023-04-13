using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        /// <summary>
        /// get api/products/GetProductWithCategory olarak görünmesi için böyle bir kullanım yaptık.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _service.GetProductWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Products = await _service.GetAllAsync();
            var ProductsDtos = _mapper.Map<List<ProductDto>>(Products.ToList());

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, ProductsDtos));
        }
        
        // Parametreli endpointlerde bu şekilde parametreyi vermek zorundayız.
        // ör: www.mysite.com/api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Product = await _service.GetByIdAsync(id);
            var ProductDtos = _mapper.Map<ProductDto>(Product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, ProductDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var Product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var ProductDtos = _mapper.Map<ProductDto>(Product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, ProductDtos)); // 201-> created
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204)); // 204-> updated
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
