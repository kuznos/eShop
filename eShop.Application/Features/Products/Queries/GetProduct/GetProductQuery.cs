using eShop.Domain;
using MediatR;
namespace eShop.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<Product?>
    {
        public Guid Id { get; set; }
    }
}
