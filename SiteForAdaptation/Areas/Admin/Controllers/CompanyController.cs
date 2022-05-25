using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SiteForAdaptation.Data;
using SiteForAdaptation.Models;
using SiteForAdaptation.Data.Entities;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CompanyController : Controller
    {
        private DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var companies = _context.Companies;

            var companyViewModel = companies.Select(c => new CompanyViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Sorting = c.Sorting,
                IsHide = c.IsHide,
            });

            return View(companyViewModel);
        }

        public IActionResult Edit(int editId)
        {
            var itemDb = _context.Companies
                .FirstOrDefault(p => p.Id == editId);

            var companyViewModel = new CompanyViewModel
            {
                Id = itemDb.Id,
                Name = itemDb.Name,
                Sorting = itemDb.Sorting,
                IsHide = itemDb.IsHide,
            };

            ViewData["Title"] = "Изменение";

            return View(companyViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CompanyViewModel item)
        {
            var itemDb = new Company
            {
                Id = item.Id,
                Name = item.Name,
                Sorting = item.Sorting,
                IsHide = item.IsHide,
            };

            if (ModelState.IsValid)
            {
                _context.Companies.Update(itemDb);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Name} сохранен";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult Create()
        {
            return View("Edit", new CompanyViewModel());
        }

        [HttpPost]
        public IActionResult Delete(int deletedId)
        {
            var deletedProduct = _context.Companies.FirstOrDefault(c => c.Id == deletedId);
            if (deletedProduct != null)
            {
                _context.Companies.Remove(deletedProduct);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{deletedProduct.Name} был удален";
            }

            return RedirectToAction("Index");
        }
    }
}
