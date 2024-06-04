using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        Shop214957326Context shopContext;

        public OrderRepository(Shop214957326Context shopContext)
        {
            this.shopContext = shopContext;
        }
        public async Task<Order> Add(Order order)
        {
            await shopContext.Orders.AddAsync(order);
            await shopContext.SaveChangesAsync();
            return order;
        }
    }
}
