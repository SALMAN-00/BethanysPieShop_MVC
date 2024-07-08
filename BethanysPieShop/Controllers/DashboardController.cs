using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace BethanysPieShop.Controllers
{
	
	public class DashboardController : Controller
	{
		private readonly PieShopDbContext _pieShopDbContext;
        public DashboardController(PieShopDbContext pieShopDbContext)
        {
			_pieShopDbContext = pieShopDbContext;
		}

        public IActionResult Index()
		{



			List<Category> Categories = _pieShopDbContext.Categories.ToList();

			return View(Categories);
		}

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Create(Category obj)
		{

			if (ModelState.IsValid)
			{
				_pieShopDbContext.Categories.Add(obj);
				_pieShopDbContext.SaveChanges();
				TempData["success"] = "Has been Created successfly";

				return RedirectToAction("Index");
			}

			return View(obj);
		}


		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			
			Category category = _pieShopDbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{	
				_pieShopDbContext.Categories.Update(obj);
				_pieShopDbContext.SaveChanges();
				TempData["success"] = "Has been Edit successfly";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category category = _pieShopDbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? obj = _pieShopDbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
			if (obj == null)
			{
				return NotFound();

			}
			_pieShopDbContext.Categories.Remove(obj);
			_pieShopDbContext.SaveChanges();
			TempData["success"] = "Has been Deleted successfly";

			return RedirectToAction("Index");
		}


	}
}
