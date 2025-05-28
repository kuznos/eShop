using FluentValidation;

namespace eShop.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(n => n.Id).NotEmpty().WithMessage("{Id} is required.").NotNull();
        }
    }
}
