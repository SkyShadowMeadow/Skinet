using API.Data;
using API.Dtos;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;


        public ProductsController(IGenericRepository<Product> productRepository, 
                                IGenericRepository<ProductBrand> productBrandRepository,
                                IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();
            var products = await _productRepository.ListAsync(spec);
            return products.Select(product => new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            }).ToList();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
             var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product =  await _productRepository.GetEntityWithSpec(spec);
            return new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            };
        }

        
        [HttpGet("brands")]
        public async Task<ActionResult<List<Product>>> GetProductBrands()
        {
            var products = await _productBrandRepository.GetList();
            return Ok(products);
        }

          [HttpGet("types")]
        public async Task<ActionResult<List<Product>>> GetProductTypes()
        {
            var products = await _productTypeRepository.GetList();
            return Ok(products);
        }
    }
} 
