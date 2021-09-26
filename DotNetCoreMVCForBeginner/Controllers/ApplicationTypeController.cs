using DotNetCoreMVCForBeginner.Data;
using DotNetCoreMVCForBeginner.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCForBeginner.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext applicationDbContext) {
            this._db = applicationDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> returnValue = _db.ApplicationType;
            
            return View(returnValue);
        }

        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            _db.ApplicationType.Add(applicationType);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
