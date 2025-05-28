using eShop.Application.Contracts.Persistence.eShop;
using eShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Persistence.Repositories.eShop
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(eShopDbContext dbContext) : base(dbContext) { }

        public Task<List<Product>> GetProductsByCategory(string category)
        {
            var products = _dbContext.Product.Where(c => c.Category.Equals(category,StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
            return products;
        }

        public Task<List<Product>> GetProductsWithDiscount()
        {
            var products = _dbContext.Product.Where(c => c.Discount > 0).ToListAsync();
            return products;
        }
    }
}
