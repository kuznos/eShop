using eShop.Domain;
using MediatR;

namespace eShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Product?>
    {
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
    }
}
