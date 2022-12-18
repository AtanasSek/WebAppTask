using DapperORMTask.Models;

namespace WebAppTask.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public void AddProduct(Product product);
        public List<dynamic> GetProductsByMostSold();
        
    }
}
