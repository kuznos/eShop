using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Features.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryValidator : AbstractValidator<GetProductsByCategoryQuery>
    {
        public GetProductsByCategoryQueryValidator()
        {
            RuleFor(n => n.Category)
              .NotEmpty().WithMessage("{Category} is required.")
              .NotNull();
        }
    }
}