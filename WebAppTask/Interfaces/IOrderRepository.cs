using DapperORMTask.Models;

namespace WebAppTask.Interfaces
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);
        public List<Order> GetOrdersByDate();
    }
}
