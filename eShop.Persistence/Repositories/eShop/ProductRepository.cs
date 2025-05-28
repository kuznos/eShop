using eShop.Application.Contracts.Persistence.eShop;
using eShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Repositories.eShop
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(eShopDbContext dbContext) : base(dbContext) { }

        public Task<List<Product>> GetProductsByCategory(string category)
        {
            var products = _dbContext.Product.Where(c => c.Category.Equals(category)).ToListAsync();
            return products;
        }

        public Task<List<Product>> GetProductsWithDiscount()
        {
            var products = _dbContext.Product.Where(c => c.Discount > 0).ToListAsync();
            return products;
        }
    }
}
