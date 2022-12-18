using DapperORMTask.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppTask.Interfaces;

namespace WebAppTask.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //
        //GET::
        //
        [Route("AllProducts")]
        public List<Product> ShowAllProducts()
        {
            return productRepository.GetAllProducts();
        }

    }
}
