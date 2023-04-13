using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Aşağıda productlar çekildiği anda kategoriler de çekiliyor. Buna "Eager Loading" denilmektedir.
        /// Ama productlar çekildikten sonra kategorilere erişilmek istenseydi Buna "Lazy Loading" denilirdi.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
