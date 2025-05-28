using Asp.Versioning;
using eShop.Api.Models;
using eShop.Application.Features.Products.Commands.CreateProduct;
using eShop.Application.Features.Products.Queries.GetProduct;
using eShop.Application.Features.Products.Queries.GetProducts;
using eShop.Application.Features.Products.Queries.GetProductsByCategory;
using eShop.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public eShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>All products.</returns>
        [ApiVersion("1.0")]
        [HttpGet("v{version:apiVersion}/products", Name = "GetAllProducts")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetAllProducts()
        {

            var result = await _mediator.Send(new GetProductsQuery() { });
            if (result?.Count > 0)
                return Ok(result);
            else
                return NotFound(result);
        }


        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A product</returns>
        [ApiVersion("1.0")]
        [HttpGet("v{version:apiVersion}/products/{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetProduct(Guid id)
        {

            var result = await _mediator.Send(new GetProductQuery() { Id = id });
            if (result is Product)
                return Ok(result);
            else
                return NotFound(result);
        }


        /// <summary>
        /// Get products by category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns>List of Products.</returns>
        [ApiVersion("1.0")]
        [HttpGet("v{version:apiVersion}/products/category/{category}", Name = "GetProductsByCategory")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetProductsByCategory(string category)
        {

            List<Product>? result = await _mediator.Send(new GetProductsByCategoryQuery() { Category = category });
            if (result?.Count > 0)
                return Ok(result);
            else
                return NotFound(result);
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="ProductRequestDTO"></param>
        /// <returns>A new product.</returns>
        [ApiVersion("1.0")]
        [HttpPost("v{version:apiVersion}/product", Name = "CreateProductAsync")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> GetDeclarationIdAsync([FromBody] ProductRequestDTO ProductRequestDTO)
        {

            Product? result = await _mediator.Send(new CreateProductCommand()
            {
                Name = ProductRequestDTO.Name,
                Category = ProductRequestDTO.Category,
                ImageName = ProductRequestDTO.ImageName,
                Price = ProductRequestDTO.Price,
                Discount = ProductRequestDTO.Discount
            });

            if (result is Product)
            {
                return Created($@"api/declaration/{result.ProductId}", result);
            }
            else
            {
                return BadRequest(result);
            }
        }


    }
}
