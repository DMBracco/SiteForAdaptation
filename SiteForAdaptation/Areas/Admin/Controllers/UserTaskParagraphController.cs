using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteForAdaptation.Data;
using SiteForAdaptation.Data.Entities;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserTaskParagraphController : Controller
    {
        private DataContext _context;

        public UserTaskParagraphController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int userTaskItemId)
        {
            var userTaskItem = new UserTaskItem();
            userTaskItem = _context.UserTaskItems.FirstOrDefault(x => x.Id == userTaskItemId);

            return View("Edit", new UserTaskParagraph { UserTaskItemId = userTaskItemId, UserTaskItem = userTaskItem });
        }

        public ActionResult Edit(int id)
        {
            var itemDb = _context.UserTaskParagraphs
                .Include(u => u.UserTaskFiles)
                .Include(s => s.UserTaskLinks)
                .Include(d => d.UserTaskItem)
                .FirstOrDefault(p => p.Id == id);

            ViewData["Title"] = $"Изменение {itemDb.UserTaskItem.Name}";

            return View(itemDb);
        }

        [HttpPost]
        public ActionResult Edit(UserTaskParagraph item)
        {
            if (ModelState.IsValid)
            {
                if(null == item.Tittle || null == item.Subtittle)
                {
                    TempData["messageType"] = $"alert-danger";
                    TempData["message"] = $"Заполните поля";

                    return RedirectToAction("Create", "UserTaskParagraph", new { userTaskItemId = item.UserTaskItemId });
                }
                _context.UserTaskParagraphs.Update(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Tittle} сохранен";

                return RedirectToAction("Edit", "UserTaskItem", new { id = item.UserTaskItemId });
            }

            TempData["messageType"] = $"alert-danger";
            TempData["message"] = $"Ошибка";

            return RedirectToAction("Edit", "UserTaskItem", new { id = item.UserTaskItemId });
        }

        [HttpPost]
        public IActionResult Delete(int deletedId)
        {
            var deletedProduct = _context.UserTaskParagraphs.FirstOrDefault(c => c.Id == deletedId);
            if (deletedProduct != null)
            {
                _context.UserTaskParagraphs.Remove(deletedProduct);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Файл '{deletedProduct.Tittle}' был удален";
            }

            return RedirectToAction("Edit", "UserTaskItem", new { id = deletedProduct.UserTaskItemId });
        }

        public async Task<IActionResult> UploadFile(IFormFile uploadFile, int paragraphId)
        {
            if (uploadFile == null || uploadFile.Length == 0)
            {

                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Файл не выбрано";

                return RedirectToAction("Edit", new { id = paragraphId });
            }

            var webPath = Guid.NewGuid() + uploadFile.FileName;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\file", $"{webPath}");


            var item = new UserTaskFile { UserTaskParagraphId = paragraphId };

            try
            {
                item.Name = uploadFile.FileName;
                item.Path = Path.Combine("file", webPath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }
                _context.UserTaskFiles.Add(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Изображение добавлено";
            }
            catch
            {
                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Ошибка при записи";

                return RedirectToAction("Edit", new { id = item.UserTaskParagraphId });
            }

            return RedirectToAction("Edit", new { id = item.UserTaskParagraphId });
        }

        public IActionResult CreateLink(UserTaskLink item)
        {
            if (ModelState.IsValid)
            {
                if (null == item.Name || null == item.Link || null == item.Icon)
                {
                    TempData["messageType"] = $"alert-danger";
                    TempData["message"] = $"Заполните поля";

                    return RedirectToAction("Edit", "UserTaskParagraph", new { id = item.UserTaskParagraphId });
                }
                _context.UserTaskLinks.Update(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Name} сохранен";

                return RedirectToAction("Edit", new { id = item.UserTaskParagraphId });
            }

            TempData["messageType"] = $"alert-danger";
            TempData["message"] = $"Ошибка";

            return RedirectToAction("Edit", new { id = item.UserTaskParagraphId });
        }

        [HttpPost]
        public IActionResult DeleteLink(int deletedId)
        {
            var deletedProduct = _context.UserTaskLinks.FirstOrDefault(c => c.Id == deletedId);
            if (deletedProduct != null)
            {
                _context.UserTaskLinks.Remove(deletedProduct);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Файл '{deletedProduct.Name}' был удален";
            }

            return RedirectToAction("Edit", new { id = deletedProduct.UserTaskParagraphId });
        }
    }
}
