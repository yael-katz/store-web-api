using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        Shop214957326Context shopContext;

        public CategoryRepository(Shop214957326Context shopContext)
        {
            this.shopContext = shopContext;
        }

        public async Task<List<Category>> Get()
        {
            List<Category> category = await shopContext.Categories.ToListAsync();
            return category;
        }
    }
}
