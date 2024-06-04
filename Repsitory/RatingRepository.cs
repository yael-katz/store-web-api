using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        Shop214957326Context shopContext;

        public RatingRepository(Shop214957326Context shopContext)
        {
            this.shopContext = shopContext;
        }
        public async Task<Rating> Add(Rating rating)
        {
            await shopContext.Set<Rating>().AddAsync(rating);
            await shopContext.SaveChangesAsync();
            return rating;
        }
    }
}
