using Microsoft.AspNetCore.Mvc;
using SiteForAdaptation.Data;
using System;
using System.Linq;

namespace SiteForAdaptation.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeStatics([FromBody] DateViewModel date)
        {
            var userStatistics = _context.UserStatistics;

            if(null == date)
            {
                date = new DateViewModel();
                date.dateEnd = DateTime.Now.Date;
                date.dateStart = DateTime.Now.AddDays(-7).Date;
            }

            var employeeStatics = userStatistics
                .Where(m => m.UserType == "Сотрудник" && m.CreatedDate >= date.dateStart && m.CreatedDate <= date.dateEnd)
                .GroupBy(p => p.CreatedDate)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                //.OrderByDescending(x => x.Name)
                ;

            return Json(employeeStatics);
        }

        public JsonResult GetManagerStatics([FromBody] DateViewModel date)
        {
            var userStatistics = _context.UserStatistics;

            if (null == date)
            {
                date = new DateViewModel();
                date.dateEnd = DateTime.Now.Date;
                date.dateStart = DateTime.Now.AddDays(-7).Date;
            }

            var managerStatics = userStatistics
                .Where(m => m.UserType == "Руководитель" && m.CreatedDate >= date.dateStart && m.CreatedDate <= date.dateEnd)
                .GroupBy(p => p.CreatedDate)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                //.OrderByDescending(x => x.Name)
                ;

            return Json(managerStatics);
        }

        public JsonResult GetUserStatics([FromBody] DateViewModel date)
        {
            var userStatistics = _context.UserStatistics;

            if (null == date)
            {
                date = new DateViewModel();
                date.dateEnd = DateTime.Now.Date;
                date.dateStart = DateTime.Now.AddDays(-7).Date;
            }

            var managerStatics = userStatistics
                .Where(m => m.CreatedDate >= date.dateStart && m.CreatedDate <= date.dateEnd)
                .GroupBy(p => p.CreatedDate)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                //.OrderByDescending(x => x.Name)
                ;

            return Json(managerStatics);
        }

        public JsonResult GetCompanyStatics([FromBody] DateViewModel date)
        {
            var userStatistics = _context.UserStatistics;

            if (null == date)
            {
                date = new DateViewModel();
                date.dateEnd = DateTime.Now.Date;
                date.dateStart = DateTime.Now.AddDays(-7).Date;
            }

            var managerStatics = userStatistics
                .Where(m => m.CreatedDate >= date.dateStart && m.CreatedDate <= date.dateEnd)
                .GroupBy(p => p.CompanyName)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                //.OrderByDescending(x => x.Name)
                ;

            return Json(managerStatics);
        }
    }

    public class DateViewModel
    {
        public DateTime? dateStart { get; set; }
        public DateTime? dateEnd { get; set; }
    }
}
