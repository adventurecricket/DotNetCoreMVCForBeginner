using DotNetCoreMVCForBeginner.Data;
using DotNetCoreMVCForBeginner.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCForBeginner.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext applicationDbContext) {
            this._db = applicationDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> returnValue = _db.Category;
            
            return View(returnValue);
        }

        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeltePost(int? id)
        {
            var category = _db.Category.Find(id);
            if (category == null)
            {
                _db.Category.Remove(category);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
