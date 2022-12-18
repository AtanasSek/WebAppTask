using Dapper;
using DapperORMTask.Models;
using MySql.Data.MySqlClient;
using WebAppTask.Context;
using WebAppTask.Interfaces;

namespace WebAppTask.Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext context;

        public CategoryRepository(DapperContext context)
        {
            this.context = context;
            
        }

        public void AddCategory(Category category)
        {
            string insertCategoryQuery = "INSERT INTO categories (CategoryName, Description, Picture) " +
                "VALUES (@CategoryName, @Description, @Picture)";

            using (var connection = context.CreateConnection())
            {

                connection.Execute(insertCategoryQuery, category);

            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories;

            System.Diagnostics.Debug.WriteLine("HELLO");

            string getCategoriesQuery = "Select * from categories";

            using (var connection = context.CreateConnection())
            {

                categories = connection.Query<Category>(getCategoriesQuery).ToList();
                System.Diagnostics.Debug.WriteLine(categories);

            }

            return categories;
        }

        public List<dynamic> GetCategoriesByMostSold()
        {
            
                
            string getProductQuery = "SELECT ProductID, ProductName, CategoryID, SUM(Quantity) " +
                "FROM (SELECT p.ProductID, p.ProductName, p.CategoryID, od.Quantity " +
                "FROM products AS p " +
                "JOIN order_details AS od ON p.ProductID = od.ProductID) AS T GROUP BY CategoryID " +
                "ORDER BY SUM(Quantity) DESC ";


            using (var connection = context.CreateConnection())
            {
                var categories = connection.Query(getProductQuery).ToList();
                

                return categories;
            }
        }
    }
}
