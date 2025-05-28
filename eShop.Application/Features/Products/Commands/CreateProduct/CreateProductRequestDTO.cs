namespace eShop.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductRequestDTO(
        string Name,
        string ImageName,
        string Category,
        decimal Price,
        decimal Discount
        ){}
}


