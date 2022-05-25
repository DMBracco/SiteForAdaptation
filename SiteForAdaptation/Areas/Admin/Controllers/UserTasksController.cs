using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteForAdaptation.Data;
using SiteForAdaptation.Data.Entities;
using SiteForAdaptation.Services;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserTasksController : Controller
    {
        private readonly DataContext _context;

        public UserTasksController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexUserType()
        {
            var dataContext = _context.Companies;
            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/UserTasks
        public async Task<IActionResult> Index(int companyId)
        {
            var dataContext = _context.UserTasks.Include(u => u.Company).Include(u => u.UserType).Include(i => i.Items)
                .Where(s => s.CompanyId == companyId);

            var userTask = _context.Companies.FirstOrDefault(s => s.Id == companyId);

            ViewBag.CompanyName = userTask?.Name;
            ViewBag.CompanyId = userTask?.Id;

            return View(await dataContext.ToListAsync());
        }

        // GET: Admin/UserTasks/Create
        public IActionResult Create(int companyId)
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "Tittle");

            return View("Edit", new UserTask { CompanyId = companyId });
        }


        // GET: Admin/UserTasks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["Title"] = "Изменение";

            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", userTask.CompanyId);
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "Tittle", userTask.UserTypeId);
            return View(userTask);
        }

        // POST: Admin/UserTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(userTask.Id == 0)
                        _context.Add(userTask);
                    else
                        _context.Update(userTask);
                    
                    await _context.SaveChangesAsync();

                    TempData["messageType"] = $"alert-success";
                    TempData["message"] = $"{userTask.Tittle} сохранен";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTaskExists(userTask.Id))
                    {
                        TempData["messageType"] = $"alert-danger";
                        TempData["message"] = $"Ошибка";

                        return View(userTask);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { companyId = userTask.CompanyId });
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", userTask.CompanyId);
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "Id", userTask.UserTypeId);
            return View(userTask);
        }

        // POST: Admin/UserTasks/Delete/5
        public async Task<IActionResult> Delete(int deletedId)
        {
            var userTask = await _context.UserTasks.FindAsync(deletedId);
            
            if (userTask != null)
            {
                _context.UserTasks.Remove(userTask);
                await _context.SaveChangesAsync();

                TempData["messageType"] = $"alert-success";
                TempData["message"] = $"Файл '{userTask.Tittle}' был удален";

                return RedirectToAction("Index", new { companyId = userTask.CompanyId });
            }
            TempData["messageType"] = $"alert-danger";
            TempData["message"] = $"Ошибка";

            return RedirectToAction("Index", new { companyId = userTask.CompanyId });
        }

        private bool UserTaskExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }

        public async Task<IActionResult> UploadFile(IFormFile uploadFile, int userTaskId)
        {
            var item = _context.UserTasks.FirstOrDefault(c => c.Id == userTaskId);

            var oldPath = new string("00");
            if (uploadFile == null || uploadFile.Length == 0)
            {

                TempData["messageType"] = $"alert-danger";
                TempData["message"] = $"Изображение не выбрано";

                return RedirectToAction("Index", new { companyId = item.CompanyId });
            }

            var webPath = Guid.NewGuid() + uploadFile.FileName;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\file", $"{webPath}");

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

                return RedirectToAction("Index", new { companyId = item.CompanyId });
            }
            WorkingFileServer.Deleted(oldPath);

            return RedirectToAction("Edit", new { id = item.Id });
        }
    }
}
