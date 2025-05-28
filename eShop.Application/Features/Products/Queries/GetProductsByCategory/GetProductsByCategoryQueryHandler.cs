using AutoMapper;
using eShop.Application.Contracts.Persistence.eShop;
using eShop.Application.Features.Products.Queries.GetProduct;
using eShop.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Features.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery,List<Product>?>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsByCategoryQueryHandler> _logger;
        private readonly IProductRepository _productsRepository;

        public GetProductsByCategoryQueryHandler(IMapper mapper, ILogger<GetProductsByCategoryQueryHandler> logger, IProductRepository productsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public async Task<List<Product>?> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Product>? products = new();
            try
            {
                var validator = new GetProductsByCategoryQueryValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var ve in validationResult.Errors)
                    {
                        _logger.LogWarning($@"Validation error on GetProductsByCategory Query for Category {request.Category}, {string.Join(",", ve.ErrorMessage)}");
                    }
                    return products;
                }
                else
                {
                    products = await _productsRepository.GetProductsByCategory(request.Category);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on GetProductsByCategory with Category {request.Category}" + Environment.NewLine + ex.Message);
            }
            return products;
        }
    }
}
