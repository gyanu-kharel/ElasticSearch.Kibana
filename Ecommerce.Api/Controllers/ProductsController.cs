using Ecommerce.Core.Dtos.Products;
using Ecommerce.Core.Interfaces;
using Ecommerce.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IElasticClient _elastic;

        public ProductsController(IProductService productService, IElasticClient elastic)
        {
            this.productService = productService;
            _elastic = elastic;
        }

        [HttpPost(Name ="CreateProuct")]
        public IActionResult CreateProduct([FromBody] CreateProductDto data)
        {
            Product result = productService.Create(data);

            _elastic.IndexDocument(result);
            return CreatedAtRoute("Get", new { id = result.Id }, result);
        }

        [HttpGet("Search", Name = "Search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var results = await _elastic.SearchAsync<Product>( s => 
                s.Query( q => q.QueryString(
                    d => d.Query("name:" + "*" + keyword + "*")
                    )
                ).Size(10) 
            );

            return Ok(results?.Documents?.ToList());
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(productService.GetAll());
        }

        [HttpGet("{id}", Name="Get")]
        public IActionResult GetById(int id)
        {
            return Ok(productService.GetAll().Where(x=> x.Id == id).FirstOrDefault());
        }
    }
}