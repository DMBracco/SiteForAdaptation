using Microsoft.AspNetCore.Mvc;
using SiteForAdaptation.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SiteForAdaptation.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var contact = _context.Contacts.Include(d => d.Company);

            //var companies = from com in _context.Companies
            //                join con in _context.Contacts
            //                on com.Id equals con.CompanyId
            //                into CompaniesContactsGroup
            //                from contacts in CompaniesContactsGroup.DefaultIfEmpty()
            //                select new { com, contacts };

            //var companiesWithoutContacts = companies.Where(s => s.contacts == null).Select(d => d.com);

            //ViewBag.Companies = new SelectList(companiesWithoutContacts, "Id", "Name");

            var companies = _context.Companies;

            return View(companies);
        }

        public IActionResult Create(Contact item)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Id} сохранен";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult ContactItem(int companyId)
        {
            var companies = _context.Companies.Include(s => s.Contact).FirstOrDefault(c => c.Id == companyId);
            if (companies.Contact == null)
            {
                _context.Contacts.Add(new Contact { CompanyId = companyId });
                _context.SaveChanges();
            }

            var contact = _context.Contacts.Include(d => d.Company).Include(c => c.Items).ThenInclude(s => s.UserType).FirstOrDefault(c => c.CompanyId == companyId);

            return View(contact);
        }

        public IActionResult EditContactItem(int editId)
        {
            var itemDb = _context.ContactItems
                .FirstOrDefault(p => p.Id == editId);

            ViewData["Title"] = "Изменение";
            ViewBag.ContactId = itemDb.ContactId;

            var userTypes = _context.UserTypes;
            ViewBag.UserTypes = new SelectList(userTypes, "Id", "Tittle", itemDb.UserTypeId);

            return View(itemDb);
        }

        [HttpPost]
        public IActionResult EditContactItem(ContactItem item)
        {
            if (ModelState.IsValid)
            {
                _context.ContactItems.Update(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Tittle} сохранен";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public IActionResult CreateContactItem(int contactId)
        {
            ViewData["Title"] = "Создание";
            ViewBag.ContactId = contactId;

            var userTypes = _context.UserTypes;
            ViewBag.UserTypes = new SelectList(userTypes, "Id", "Tittle");

            return View("EditContactItem", new ContactItem());
        }

        [HttpPost]
        public IActionResult DeleteContactItem(int deletedId)
        {
            var deletedProduct = _context.ContactItems.FirstOrDefault(c => c.Id == deletedId);

            var contactId = deletedProduct.ContactId;

            if (deletedProduct != null)
            {
                _context.ContactItems.Remove(deletedProduct);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{deletedProduct.Tittle} был удален";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UploadFile(IFormFile file, int id)
        {
            if (file == null || file.Length == 0)
                return Json("файл не выбран");

            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\file",
                        file.FileName);


            contact.FileName = file.FileName;
            contact.FilePath = Path.Combine("file", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            _context.SaveChanges();

            return Json(contact.FileName);
        }
    }
}
