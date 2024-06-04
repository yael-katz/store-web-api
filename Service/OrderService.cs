using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;
        private IProductService productService;
        private readonly ILogger<OrderService> logger;
        public OrderService(IOrderRepository orderRepository, IProductService productService, ILogger<OrderService> logger)
        {
            this.logger = logger;
            this.orderRepository = orderRepository;
            this.productService = productService;
        }


        public async Task<Order> Add(Order order)
        {

            List<Product> productList = await productService.Get();
         
            decimal totalSum = (decimal)order.OrderItems?.Where(oi => productList.Any(p => p?.ProductId == oi?.ProductId))
            .Sum(oi => productList.First(p => p?.ProductId == oi?.ProductId).Price * oi.Quantity);
            Console.Write("  totalSum  " + totalSum);
            Console.Write("  order.OrderSum  " + order.OrderSum);
            if (order.OrderSum != totalSum)
            {
                Console.WriteLine("ERR");
                logger.LogError("🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️there is a stoller in the shop🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️🏴‍☠️");
                return null;
            }
            else
            {
                Console.Write("  good  " + totalSum);
                Order reasult = await orderRepository.Add(order);
                if (reasult == null)
                    return null;
                return reasult;
            }

            //int sum = 0;
            //List<Product> products = await productService.Get();
            //foreach (var product in products)
            //{
            //    foreach (var item in order.OrderItems)
            //    {
            //        if (product.ProductId == item.ProductId)
            //        {
            //            sum += (product.Price ?? 0) * (item.Quantity ?? 0);
            //        }
            //    }
            //}
            //if (sum != order.OrderSum)
            //{

            //    throw new Exception("price not valid");
            //}

      
        }
    }
}
