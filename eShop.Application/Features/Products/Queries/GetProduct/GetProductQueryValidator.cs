using FluentValidation;

namespace eShop.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(n => n.Id)
              .NotEmpty().WithMessage("{Id} is required.")
              .NotNull();
        }
    }
}
