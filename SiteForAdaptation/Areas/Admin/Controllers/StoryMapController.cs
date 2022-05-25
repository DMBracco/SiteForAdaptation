using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class StoryMapController : Controller
    {
        private DataContext _context;

        public StoryMapController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var storyMap = _context.StoryMaps.Include(s => s.UserType)
                .OrderBy(o => o.UserTypeId)
                .ThenBy(o => o.Number);

            return View(storyMap);
        }

        public IActionResult Edit(int editId)
        {
            var itemDb = _context.StoryMaps
                //.Include(s => s.UserType)
                //.Include(s => s.StoryItems)
                .FirstOrDefault(p => p.Id == editId);

            ViewData["Title"] = "Изменение";

            ViewBag.SelectListUserType = SelectUserType();

            return View(itemDb);
        }

        [HttpPost]
        public IActionResult Edit(StoryMap item)
        {
            if (ModelState.IsValid)
            {
                _context.StoryMaps.Update(item);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"{item.Name} сохранен";

                return RedirectToAction("Edit", new { editId = item.Id });
            }

            TempData["messageType"] = $"alert-danger";
            TempData["message"] = $"Ошибка";

            return RedirectToAction("Edit", new { editId = item.Id });
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Добавление";

            ViewBag.SelectListUserType = SelectUserType();

            return View("Edit", new StoryMap());
        }

        public SelectList SelectUserType()
        {
            var userTypes = _context.UserTypes;
            var selectList = new SelectList(userTypes, "Id", "Tittle");
            return selectList;
        }

        [HttpPost]
        public IActionResult Delete(int deletedId)
        {
            var deletedProduct = _context.StoryMaps.FirstOrDefault(c => c.Id == deletedId);
            if (deletedProduct != null)
            {
                _context.StoryMaps.Remove(deletedProduct);
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Файл '{deletedProduct.Name}' был удален";
            }

            return RedirectToAction("Index");
        }

        //public IActionResult CreateItem(StoryItem item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.StoryItems.Update(item);
        //        _context.SaveChanges();

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"{item.Tittle} сохранен";

        //        return RedirectToAction("Edit", new { editId = item.StoryMapId });
        //    }

        //    TempData["messageType"] = $"alert-danger";
        //    TempData["message"] = $"Ошибка";

        //    return RedirectToAction("Edit", new { editId = item.StoryMapId });
        //}

        //[HttpPost]
        //public IActionResult DeleteItem(int deletedId)
        //{
        //    var deletedProduct = _context.StoryItems.FirstOrDefault(c => c.Id == deletedId);
        //    if (deletedProduct != null)
        //    {
        //        _context.StoryItems.Remove(deletedProduct);
        //        _context.SaveChanges();

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"Файл '{deletedProduct.Tittle}' был удален";
        //    }

        //    return RedirectToAction("Edit", new { editId = deletedProduct.StoryMapId });
        //}

        //public async Task<IActionResult> UploadImg(IFormFile uploadedImg, int storyMapId)
        //{
        //    var oldPath = new string("00");
        //    if (uploadedImg == null || uploadedImg.Length == 0)
        //    {

        //        TempData["messageType"] = $"alert-danger";
        //        TempData["message"] = $"Изображение не выбрано";

        //        return RedirectToAction("Index");
        //    }

        //    var webPath = Guid.NewGuid() + uploadedImg.FileName;

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot\\file", $"{webPath}");


        //    var item = _context.StoryMaps.FirstOrDefault(c => c.Id == storyMapId);

        //    try
        //    {
        //        if (null != item.ImagePath)
        //            oldPath = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot\\", item.ImagePath);

        //        item.ImageName = uploadedImg.FileName;
        //        item.ImagePath = Path.Combine("file/", webPath);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await uploadedImg.CopyToAsync(stream);
        //        }
        //        _context.SaveChanges();

        //        TempData["messageType"] = $"alert-success";
        //        TempData["message"] = $"Изображение добавлено";
        //    }
        //    catch
        //    {
        //        TempData["messageType"] = $"alert-danger";
        //        TempData["message"] = $"Ошибка при записи";

        //        return RedirectToAction("Index");
        //    }
        //    WorkingFileServer.Deleted(oldPath);

        //    return RedirectToAction("Edit", new { editId = item.Id });
        //}

        public async Task<IActionResult> UploadFile(IFormFile uploadFile, int storyMapId)
        {
            var oldPath = new string("00");
            if (uploadFile == null || uploadFile.Length == 0)
            {

                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Изображение не выбрано";

                return RedirectToAction("Index");
            }

            var webPath = Guid.NewGuid() + uploadFile.FileName;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\file", $"{webPath}");


            var item = _context.StoryMaps.FirstOrDefault(c => c.Id == storyMapId);

            try
            {
                if (null != item.FilePath)
                    oldPath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\", item.FilePath);

                item.FileName = uploadFile.FileName;
                item.FilePath = Path.Combine("file", webPath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Изображение добавлено";
            }
            catch
            {
                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Ошибка при записи";

                return RedirectToAction("Index");
            }
            WorkingFileServer.Deleted(oldPath);

            return RedirectToAction("Edit", new { editId = item.Id });
        }
    }
}
