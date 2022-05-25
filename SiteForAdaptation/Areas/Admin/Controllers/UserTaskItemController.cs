using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteForAdaptation.Data;
using SiteForAdaptation.Data.Entities;
using SiteForAdaptation.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserTaskItemController : Controller
    {
        private DataContext _context;

        public UserTaskItemController(DataContext context)
        {
            _context = context;
        }

        // GET: UserTaskItemController
        public ActionResult Index(int userTaskId)
        {
            var dataContext = _context.UserTaskItems.Include(u => u.Paragraphs).Include(u => u.UserTask)
                .Where(s => s.UserTaskId == userTaskId);

            ViewBag.UserTask = _context.UserTasks.FirstOrDefault(u => u.Id == userTaskId);

            return View(dataContext);
        }

        // GET: UserTaskItemController/Create
        public ActionResult Create(int userTaskId)
        {
            return View("Edit", new UserTaskItem { UserTaskId = userTaskId });
        }

        // GET: UserTaskItemController/Edit/5
        public ActionResult Edit(int id)
        {
            var itemDb = _context.UserTaskItems.Include(u => u.Paragraphs).ThenInclude(s => s.UserTaskFiles)
                .FirstOrDefault(p => p.Id == id);

            ViewData["Title"] = "Изменение";

            return View(itemDb);
        }

        // POST: UserTaskItemController/Edit/5
        [HttpPost]
        public ActionResult Edit(UserTaskItem item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                    _context.Add(item);
                else
                    _context.UserTaskItems.Update(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Name} сохранен";

                return View(item);
            }

            TempData["messageType"] = $"alert-danger";
            TempData["message"] = $"Ошибка";

            return View(item);
        }

        // GET: UserTaskItemController/Delete/5
        public ActionResult Delete(int deletedId)
        {
            var deletedProduct = _context.UserTaskItems.FirstOrDefault(c => c.Id == deletedId);
            if (deletedProduct != null)
            {
                _context.UserTaskItems.Remove(deletedProduct);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Файл '{deletedProduct.Name}' был удален";

                return RedirectToAction("Index", new { userTaskId = deletedProduct.UserTaskId });
            }

            TempData["messageType"] = $"alert-danger";
            TempData["message"] = $"Ошибка";

            return RedirectToAction("Index", new { userTaskId = deletedProduct.UserTaskId });
        }

        //public IActionResult CreateItem(UserTaskParagraph item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.UserTaskParagraphs.Update(item);
        //        _context.SaveChanges();

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"{item.Tittle} сохранен";

        //        return RedirectToAction("Edit", new { id = item.UserTaskItemId });
        //    }

        //    TempData["messageType"] = $"alert-danger";
        //    TempData["message"] = $"Ошибка";

        //    return RedirectToAction("Edit", new { id = item.UserTaskItemId });
        //}

        //[HttpPost]
        //public IActionResult DeleteItem(int deletedId)
        //{
        //    var deletedProduct = _context.UserTaskParagraphs.FirstOrDefault(c => c.Id == deletedId);
        //    if (deletedProduct != null)
        //    {
        //        _context.UserTaskParagraphs.Remove(deletedProduct);
        //        _context.SaveChanges();

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"Файл '{deletedProduct.Tittle}' был удален";
        //    }

        //    return RedirectToAction("Edit", new { id = deletedProduct.UserTaskItemId });
        //}

        //public async Task<IActionResult> UploadFile(IFormFile uploadFile, int paragraphId)
        //{
        //    if (uploadFile == null || uploadFile.Length == 0)
        //    {

        //        TempData["messageType"] = $"alert-danger";
        //        TempData["message"] = $"Изображение не выбрано";

        //        return RedirectToAction("Edit", new { id = paragraphId });
        //    }

        //    var webPath = Guid.NewGuid() + uploadFile.FileName;

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot\\file", $"{webPath}");


        //    var item = new UserTaskFile { UserTaskParagraphId = paragraphId };

        //    try
        //    {
        //        item.Name = uploadFile.FileName;
        //        item.Path = Path.Combine("file", webPath);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await uploadFile.CopyToAsync(stream);
        //        }
        //        _context.UserTaskFiles.Add(item);
        //        _context.SaveChanges();

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"Изображение добавлено";
        //    }
        //    catch
        //    {
        //        TempData["messageType"] = $"alert-danger";
        //        TempData["message"] = $"Ошибка при записи";

        //        return RedirectToAction("Edit", new { id = item.UserTaskParagraphId });
        //    }

        //    return RedirectToAction("Edit", new { id = item.UserTaskParagraphId });
        //}

        //public IActionResult DeleteFile(int deletedId)
        //{
        //    var deletedProduct = _context.UserTaskFiles.FirstOrDefault(c => c.Id == deletedId);
        //    if (deletedProduct != null)
        //    {
        //        _context.UserTaskFiles.Remove(deletedProduct);
        //        _context.SaveChanges();

        //        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\", deletedProduct.Path);
        //        WorkingFileServer.Deleted(oldPath);

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"Файл '{deletedProduct.Name}' был удален";
        //    }

        //    return RedirectToAction("Edit", new { id = deletedProduct.UserTaskParagraphId });
        //}
    }
}
