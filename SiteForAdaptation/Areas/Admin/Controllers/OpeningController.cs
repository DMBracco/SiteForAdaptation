using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteForAdaptation.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteForAdaptation.Services;
using System;
using System.Collections.Generic;
using SiteForAdaptation.Data.Entities;
using Microsoft.AspNetCore.Hosting;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OpeningController : Controller
    {
        private DataContext _context;
        private IWebHostEnvironment _appEnvironment;

        public OpeningController(DataContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var openings = new List<Opening>();
            openings = _context.Openings.Include(s => s.UserType).ToList();
            return View(openings);
        }

        //public async Task<IActionResult> UploadImg(IFormFile uploadedImg, int userTypeId)
        //{
        //    var oldPath = new string("00");
        //    if (uploadedImg == null || uploadedImg.Length == 0)
        //    {

        //        TempData["messageType"] = $"alert-danger";
        //        TempData["message"] = $"Изображение не выбрано";

        //        return RedirectToAction("Index");
        //    }

        //    var webPath = Guid.NewGuid()+uploadedImg.FileName;

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot\\file", $"{webPath}");

        //    try
        //    {
        //        var item = _context.Openings.FirstOrDefault(c => c.UserTypeId == userTypeId);

        //        if (null != item.ImagePath)
        //            oldPath = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot\\", item.ImagePath);

        //        item.ImageName = uploadedImg.FileName;
        //        item.ImagePath = Path.Combine("file", webPath);

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

        //    return RedirectToAction("Index");
        //}

        public IActionResult AddVideo(string inputVideoPath, int userTypeId)
        {
            if (inputVideoPath== null)
            {

                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Строки пустые";

                return RedirectToAction("Index");
            }

            try
            {
                var item = _context.Openings.FirstOrDefault(c => c.UserTypeId == userTypeId);

                if (null != item)
                {
                    item.VideoPath = inputVideoPath;
                    //item.VideoName = inputVideoName;

                    _context.SaveChanges();
                }

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Видео добавлено";
            }
            catch
            {
                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Ошибка при записи";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UploadFile(IFormFile uploadFile, int userTypeId)
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
                        _appEnvironment.WebRootPath, "file", $"{webPath}");

            try
            {
                var item = _context.Openings.FirstOrDefault(c => c.UserTypeId == userTypeId);

                if(null != item.FilePath)
                    oldPath = Path.Combine(
                        _appEnvironment.WebRootPath, item.FilePath);

                //item.FileName = uploadFile.FileName;
                item.FilePath = Path.Combine("file", webPath);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(stream);
                }
                _context.SaveChanges();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Изображение добавлено";
            }
            catch(Exception ex)
            {
                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Ошибка при записи {ex}";

                return RedirectToAction("Index");
            }
            WorkingFileServer.Deleted(oldPath);

            return RedirectToAction("Index");
        }
    }
}
