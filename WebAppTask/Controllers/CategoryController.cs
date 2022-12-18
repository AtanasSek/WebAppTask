using DapperORMTask.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppTask.Interfaces;

namespace WebAppTask.Controllers
{
    
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //
        //GET: Return all categories
        //
        [Route("AllCategories")]
        public List<Category> ShowAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

    }
}
