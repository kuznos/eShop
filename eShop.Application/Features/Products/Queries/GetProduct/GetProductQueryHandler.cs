﻿using AutoMapper;
using eShop.Application.Contracts.Persistence.eShop;
using eShop.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eShop.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductQueryHandler> _logger;
        private readonly IProductRepository _productsRepository;

        public GetProductQueryHandler(IMapper mapper, ILogger<GetProductQueryHandler> logger, IProductRepository productsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productsRepository = productsRepository;
        }

		public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
		{
			Product? product = null;
			try
			{
				var validator = new GetProductQueryValidator();
				var validationResult = await validator.ValidateAsync(request, cancellationToken);
				if (validationResult.Errors.Count > 0)
				{
					foreach (var ve in validationResult.Errors)
					{
						_logger.LogWarning($@"Validation error on GetProduct Query for Id {request.Id}, {string.Join(",", ve.ErrorMessage)}");
					}
					return product;
				}
				else
				{
					product = await _productsRepository.GetByIdAsync(request.Id);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($@"Error on GetProduct with RequestId {request.Id}" + Environment.NewLine + ex.Message);
			}
			return product;
		}
	}
}
