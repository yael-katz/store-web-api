using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        Shop214957326Context shopContext;

        public ProductRepository(Shop214957326Context shopContext)
        {
            this.shopContext = shopContext;
        }

        public async Task<List<Product>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = shopContext.Products.Include(p => p.Category).Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            //.Skip((position - 1) * skip)
            //.Take(skip);
            await Console.Out.WriteLineAsync(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }

        public async Task<List<Product>> Get()
        {
            return await shopContext.Products.ToListAsync();
        }
    }
}
