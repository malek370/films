using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication2.Models.data;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly appDbContext db;
        public CategoryController(appDbContext db)
        {
            this.db = db;
        }

        public  IActionResult Index()
        {
            List<Category> cats= db.categories.ToList();
            return View(cats);
        }

        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Creat(Category c)
        {
			c.abb = c.abb.ToUpper();
            c.Id = c.abb.toId();
			if (db.categories.Find(c.Id) != null) { ModelState.AddModelError("abb", "already exist");}
            if (ModelState.IsValid)
            {
                db.categories.Add(c);
                await db.SaveChangesAsync();
                TempData["success"] = $"category {c.abb} has been created";
                return RedirectToAction("Index");
            }
            return View();
                
        }

		public IActionResult Edit(int? id)
		{
            Category? category = db.categories.Find(id);
            if (category == null) { return NotFound(); }
			return View(category);
		}
		[HttpPost]
        
		public async Task<IActionResult> Edit( Category c)
		{
			if (db.categories.AsNoTracking().First(e=>e.Id==c.Id)==null) { return NotFound(); }

			try{
				
				db.categories.Update(c);
				await db.SaveChangesAsync();
				TempData["success"] = $"category {c.abb} has been changed";
				return RedirectToAction("Index");
			}
            catch(Exception ex) 
            {
                TempData["fail"] = ex.Message;
				return RedirectToAction("Index");
			}

		}
		public async Task<IActionResult> Delete(int? id)
		{
			Category? category = db.categories.Find(id);
			if (category == null) { return NotFound(); }
			try
			{

				db.categories.Remove(category);
				await db.SaveChangesAsync();
				TempData["success"] = $"category {category.abb} has been changed";
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				TempData["fail"] = ex.Message;
				return RedirectToAction("Index");
			}
		}
	}
}
