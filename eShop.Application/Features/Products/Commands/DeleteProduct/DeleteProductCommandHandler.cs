using AutoMapper;
using eShop.Application.Contracts.Persistence.eShop;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eShop.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ILogger<DeleteProductCommandHandler> _logger;
        private readonly IProductRepository _productsRepository;

		public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IProductRepository productsRepository)
		{
			_logger = logger;
			_productsRepository = productsRepository;
		}

		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           bool result = false;
            try
            {
                var validator = new DeleteProductCommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Count > 0)
                {
                    foreach (var ve in validationResult.Errors)
                    {
                        _logger.LogWarning($@"Validation error on Delete Product Command for Id {request.Id}, {string.Join(",", ve.ErrorMessage)}");
                    }
                    return false;
                }
                else
                {
                    var productToDelete = await _productsRepository.GetByIdAsync(request.Id);
                    if (productToDelete != null)
                    {
                        await _productsRepository.DeleteAsync(productToDelete);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($@"Error on Delete Product Command with Id {request.Id}" + Environment.NewLine + ex.Message);
            }
            return result;
        }
    }
}
