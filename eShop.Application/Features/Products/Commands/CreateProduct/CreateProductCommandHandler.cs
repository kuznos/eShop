using AutoMapper;
using eShop.Application.Contracts.Persistence.eShop;
using eShop.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product?>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IProductRepository _productsRepository;

        public CreateProductCommandHandler(IMapper mapper, ILogger<CreateProductCommandHandler> logger, IProductRepository productsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public async Task<Product?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product? result = null;
            try
            {
                var validator = new CreateProductCommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var ve in validationResult.Errors)
                    {
                        _logger.LogWarning($@"Validation error on CreateProduct Command, {string.Join(",", ve.ErrorMessage)}");
                    }
                    return result;
                }
                else
                {
                    var product = _mapper.Map<Product>(request);
                    result = await _productsRepository.AddAsync(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
            
        }
    }
}
