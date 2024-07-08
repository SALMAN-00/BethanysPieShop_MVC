namespace BethanysPieShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly PieShopDbContext _bethanysPieShopDbContext;

        public CategoryRepository(PieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _bethanysPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
