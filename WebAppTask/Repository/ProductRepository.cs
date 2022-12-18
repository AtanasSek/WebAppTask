using Dapper;
using DapperORMTask.Models;
using WebAppTask.Context;
using WebAppTask.Interfaces;

namespace WebAppTask.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly DapperContext context;

        public ProductRepository(DapperContext context)
        {
            this.context = context;
        }

        //POST: Add a new product
        public void AddProduct(Product product)
        {
            //Sigurno ima poubav i popregleden nacin?
            string insertProductQuery = "INSERT INTO products(ProductName, SupplierID, CategoryID, " +
                "QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, " +
                "ReorderLevel, Discontinued, LastUserId, LastDateUpdated)" +
                "VALUES (@ProductName, @SupplierID, @CategoryID, " +
                "@QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, " +
                "@ReorderLevel, @Discontinued, @LastUserId, @LastDateUpdated)";

            using (var connection = context.CreateConnection())
            {
                connection.Execute(insertProductQuery, product);
            }
        }

        //GET: Return all categories
        public List<Product> GetAllProducts()
        {
            List<Product> products;
            string getCategoriesQuery = "Select * from products";


            using (var connection = context.CreateConnection())
            {
                products = connection.Query<Product>(getCategoriesQuery).ToList();
            }

            return products;
        }

        //GET: Return products sorted by most sold
        public List<dynamic> GetProductsByMostSold()
        {
            string getProductQuery = "SELECT ProductID, ProductName, CategoryID, SUM(Quantity) " +
                "FROM (SELECT p.ProductID, p.ProductName, p.CategoryID, od.Quantity " +
                "FROM products AS p " +
                "JOIN order_details AS od ON p.ProductID = od.ProductID) AS T GROUP BY ProductID " +
                "ORDER BY SUM(Quantity) DESC ";


            using (var connection = context.CreateConnection())
            {
                var products = connection.Query(getProductQuery).ToList();

                return products;
            }
        }
    }
}
