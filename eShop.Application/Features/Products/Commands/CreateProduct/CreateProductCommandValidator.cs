using FluentValidation;

namespace eShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("Product Name is required").NotNull();
            RuleFor(n => n.Category).NotEmpty().WithMessage("Product Category is required").NotNull();
            RuleFor(n => n.ImageName).NotEmpty().WithMessage("Product ImageName is required").NotNull();
        }
    }
}
