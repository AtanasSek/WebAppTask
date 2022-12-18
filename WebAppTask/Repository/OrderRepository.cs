using Dapper;
using DapperORMTask.Models;
using WebAppTask.Context;
using WebAppTask.Interfaces;

namespace WebAppTask.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext context;

        public OrderRepository(DapperContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            string insertOrderQuery = "INSERT INTO orders(CustomerID, EmployeeID, OrderDate, " +
                "RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity," +
                "ShipRegion, ShipPostalCode, ShipCountry )" +
                "VALUES (@CustomerID, @EmployeeID, @OrderDate, " +
                "@RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity," +
                "@ShipRegion, @ShipPostalCode, @ShipCountry)";


            using (var connection = context.CreateConnection())
            {
                connection.Execute(insertOrderQuery, order);
            }
        }

        public List<Order> GetOrdersByDate()
        {
            string getOrderQuery = "SELECT * FROM orders ORDER BY OrderDate, RequiredDate, ShippedDate";
            List<Order> orders;

            using (var connection = context.CreateConnection())
            {
                orders = connection.Query<Order>(getOrderQuery).ToList();
            }
            return orders;
        }
    }
}
