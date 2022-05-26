using Microsoft.AspNetCore.Mvc;
using SiteForAdaptation.Data;
using SiteForAdaptation.Models;
using System;
using System.Collections.Generic;
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

        public IActionResult UserStatistics()
        {
            var userStatisticslist = new List<UserStatisticsViewModel>();

            var userStatistics = _context.UserStatistics.OrderBy(d => d.CreatedDate);
            //var distinctUsers = userStatistics.GroupBy(x => x.UserEmail).Select(y => y.First());
            var todayDate = DateTime.Now.Date;

            foreach (var distinctUser in userStatistics)
            {
                var userStatisticsView = new UserStatisticsViewModel();

                userStatisticsView.UserType = distinctUser.UserType;
                userStatisticsView.UserEmail = distinctUser.UserEmail;
                userStatisticsView.CompanyName = distinctUser.CompanyName;

                if ((todayDate - distinctUser.CreatedDate).TotalDays > 15)
                {
                    userStatisticsView.Status = "прошедший";
                    userStatisticsView.StatusTextColor = "text-success";
                }
                else if ((todayDate - distinctUser.CreatedDate).TotalDays > 4)
                {
                    userStatisticsView.Status = "продолжающий";
                    userStatisticsView.StatusTextColor = "text-warning";
                }
                else
                {
                    userStatisticsView.Status = "начинающий";
                    userStatisticsView.StatusTextColor = "text-danger";
                }
                userStatisticslist.Add(userStatisticsView);
            }

            return View(userStatisticslist);
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
