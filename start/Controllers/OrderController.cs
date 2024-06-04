using AutoMapper;
using Entities;
using Entities.DtoOrder;
using Entities.DtoOrderItem;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace start.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : Controller
    {

        IOrderService orderService;
        IMapper mapper;
        public OrderController(IOrderService orderService,IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }
      
       [HttpPost]
        public async Task<ActionResult<AddOrderDto>> Add(AddOrderDto order)
        {
            Order newOrder = mapper.Map<Order>(order);

            Order res = await orderService.Add(newOrder);

            AddOrderDto addOrder = mapper.Map<AddOrderDto>(res);

            if (addOrder != null)
                return Ok(addOrder);
            return BadRequest();

        }

    }
}
