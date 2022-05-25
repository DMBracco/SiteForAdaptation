using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteForAdaptation.Data;
using SiteForAdaptation.Data.Entities;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemoForManagersController : Controller
    {
        private readonly DataContext _context;

        public MemoForManagersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult IndexCompany()
        {
            var dataContext = _context.Companies;
            return View(dataContext);
        }

        // GET: Admin/MemoForManagers
        public IActionResult Index(int companyId)
        {
            var data = new MemoForManager();
            var dataContext = _context.MemoForManagers.FirstOrDefault(s => s.CompanyId == companyId);
            if(dataContext == null)
            {
                data.CompanyId = companyId;
                _context.MemoForManagers.Add(data);
                _context.SaveChanges();
            }
            data = _context.MemoForManagers.Include(m => m.Company).FirstOrDefault(s => s.CompanyId == companyId);

            return View(data);
        }

        // GET: Admin/MemoForManagers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoForManager = _context.MemoForManagers.Include(m => m.Company).FirstOrDefault(s => s.Id == id);
            if (memoForManager == null)
            {
                return NotFound();
            }
            //ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", memoForManager.CompanyId);
            return View(memoForManager);
        }

        // POST: Admin/MemoForManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Tittle_1,Subtittle_1,Tittle_2,Subtittle_2,Tittle_3,Subtittle_3,Tittle_4,Subtittle_4,Tittle_5,Subtittle_5,CompanyId")] MemoForManager memoForManager)
        {
            if (id != memoForManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memoForManager);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoForManagerExists(memoForManager.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { companyId = memoForManager.CompanyId });
            }
            //ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", memoForManager.CompanyId);
            return View(memoForManager);
        }

        private bool MemoForManagerExists(int id)
        {
            return _context.MemoForManagers.Any(e => e.Id == id);
        }
    }
}
