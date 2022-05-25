using Microsoft.AspNetCore.Mvc;
using SiteForAdaptation.Data;
using SiteForAdaptation.Data.Entities;
using System.Linq;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class NavBarController : Controller
    {
        private DataContext _context;

        public NavBarController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.NavBars);
        }

        public IActionResult Edit(int editId)
        {
            var itemDb = _context.NavBars
                .FirstOrDefault(p => p.Id == editId);

            ViewData["Title"] = "Изменение";

            return View(itemDb);
        }

        [HttpPost]
        public IActionResult Edit(NavBar item)
        {
            if (ModelState.IsValid)
            {
                _context.NavBars.Update(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.UserTypeTittle} сохранен";

                return RedirectToAction("Index");
            }

            return View(item);
        }
    }
}
