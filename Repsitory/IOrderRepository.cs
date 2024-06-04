using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order order);
    }
}