using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class CategoryMenue : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenue(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var category = _categoryRepository.AllCategories.
                OrderBy(c => c.CategoryName);
            return View(category);
        }
    }
}
