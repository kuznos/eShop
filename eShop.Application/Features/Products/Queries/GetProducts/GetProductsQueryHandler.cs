using AutoMapper;
using eShop.Application.Contracts.Persistence.eShop;
using eShop.Application.Features.Products.Queries.GetProduct;
using eShop.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>?>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductQueryHandler> _logger;
        private readonly IProductRepository _productsRepository;

        public GetProductsQueryHandler(IMapper mapper, ILogger<GetProductQueryHandler> logger, IProductRepository productsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public async Task<List<Product>?> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product>? products = null;
            try
            {
                products = (List<Product>)await _productsRepository.ListAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on GetProductsQuery" + Environment.NewLine + ex.Message);
            }
            return products;
        }
    }
}
