using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> Add(Order order);
    }
}