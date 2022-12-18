using DapperORMTask.Models;

namespace WebAppTask.Interfaces
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
        public void AddCategory(Category category);
        public List<dynamic> GetCategoriesByMostSold();
    }
}
