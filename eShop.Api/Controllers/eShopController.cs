using Asp.Versioning;
using eShop.Application.Features.Products.Queries.GetProduct;
using eShop.Application.Features.Products.Queries.GetProducts;
using eShop.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        /// Gets all product.
        /// </summary>
        /// <returns>Gets all product.</returns>
        [ApiVersion("1.0")]
        [HttpGet("v{version:apiVersion}/products", Name = "GetProducts")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> GetProducts()
        {

            var result = await _mediator.Send(new GetProductsQuery() { });
            if (result?.Count > 0)
                return Ok(result);
            else
                return NotFound(result);
        }


        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gets product by id.</returns>
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

    }
}
