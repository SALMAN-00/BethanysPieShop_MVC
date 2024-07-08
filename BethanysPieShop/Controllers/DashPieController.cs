using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class DashPieController : Controller
    {
        private readonly PieShopDbContext _pieShopDbContext;
        public DashPieController(PieShopDbContext pieShopDbContext)
        {
             _pieShopDbContext = pieShopDbContext;
        }
        public IActionResult Index()
        {
            List<Pie> Pies = _pieShopDbContext.Pies.ToList();
            return View(Pies);
        }


        public IActionResult Create()
        {
	
			return View();
        }

        [HttpPost]
        public IActionResult Create(Pie obj)
        {

            if (ModelState.IsValid)
            {
                _pieShopDbContext.Pies.Add(obj);
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

            Pie pie = _pieShopDbContext.Pies.FirstOrDefault(c => c.PieId == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        [HttpPost]
        public IActionResult Edit(Pie obj)
        {
            if (ModelState.IsValid)
            {
                _pieShopDbContext.Pies.Update(obj);
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
            Pie pie = _pieShopDbContext.Pies.FirstOrDefault(c => c.PieId == id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Pie? obj = _pieShopDbContext.Pies.FirstOrDefault(c => c.PieId == id);
            if (obj == null)
            {
                return NotFound();

            }
            _pieShopDbContext.Pies.Remove(obj);
            _pieShopDbContext.SaveChanges();
            TempData["success"] = "Has been Deleted successfly";

            return RedirectToAction("Index");
        }


    }
}
