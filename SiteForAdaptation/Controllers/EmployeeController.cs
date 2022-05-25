using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteForAdaptation.Data;
using SiteForAdaptation.Data.Entities;
using SiteForAdaptation.Models;
using System;
using System.Linq;
using System.Web;

namespace SiteForAdaptation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly DataContext _context;

        public EmployeeController(ILogger<EmployeeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        string userTypesTittle = "Сотрудник";

        public IActionResult Index()
        {
            var data = _context.Companies.Where(c => c.IsHide == false);
            var navBar = _context.NavBars.FirstOrDefault(s => s.UserTypeTittle == userTypesTittle);

            ViewBag.Companies = new SelectList(data, "Id", "Name");
            ViewBag.NavBar = navBar;

            return View();
        }

        public IActionResult FullIndex(int companyId)
        {
            var data = _context.Companies
                .Where(c => c.IsHide == false)
                .Include(c => c.Contact)
                    .ThenInclude(c => c.Items)
                .Include(s => s.UserTasks)
                    .ThenInclude(s => s.Items)
                        .ThenInclude(s => s.Paragraphs)
                            .ThenInclude(s => s.UserTaskLinks)
                .Include(s => s.UserTasks)
                    .ThenInclude(s => s.Items)
                        .ThenInclude(s => s.Paragraphs)
                            .ThenInclude(s => s.UserTaskFiles)
                .FirstOrDefault(d => d.Id == companyId);

            ViewBag.Companies = new SelectList(_context.Companies, "Id", "Name", companyId);

            var navBar = new NavBar();
            navBar = _context.NavBars.FirstOrDefault(d => d.UserTypeTittle == userTypesTittle);

            var userType = new UserType();
            userType = _context.UserTypes
                .Include(c => c.Opening)
                .Include(c => c.StoryMaps)//.ThenInclude(c => c.StoryItems)
                .FirstOrDefault(d => d.Tittle == userTypesTittle);

            var userTask = new UserTask();
            userTask = data.UserTasks?.FirstOrDefault();

            //storyMaps
            var storyMapsArray = new StoryMap[10];
            var index = 0;

            foreach (var item in userType.StoryMaps.OrderBy(s => s.Number))
            {
                storyMapsArray[index] = item;
                index++;
            }
            index = 0;

            var viewModal = new EmployeeViewModel
            {
                companyId = data.Id,
                companyName = data.Name,

                NavBarTitle_1 = navBar.Title_1,
                NavBarLink_1 = navBar.Link_1,
                NavBarTitle_2 = navBar.Title_2,
                NavBarLink_2 = navBar.Link_2,
                NavBarTitle_3 = navBar.Title_3,
                NavBarLink_3 = navBar.Link_3,
                NavBarTitle_4 = navBar.Title_4,
                NavBarLink_4 = navBar.Link_4,
                NavBarTitle_5 = navBar.Title_5,
                NavBarLink_5 = navBar.Link_5,

                openingFilePath = userType.Opening?.FilePath,
                //openingImagePath = userType.Opening?.ImagePath,
                openingVideoPath = userType.Opening?.VideoPath,

                userTaskTittle = userTask?.Tittle,
                userTaskSubtittle = userTask?.Subtittle,
                userTaskText = userTask?.Text,
                userTaskFilePath = userTask?.FilePath,

                contactFileName = data.Contact?.FileName,
                contactFilePath = data.Contact?.FilePath
            };

            #region storyMaps
            if (null != storyMapsArray[0])
            {
                viewModal.storyMapsName_1 = storyMapsArray[0].Name;
                viewModal.storyMapsNumber_1 = storyMapsArray[0].Number;
                viewModal.storyMapsTittle_1 = storyMapsArray[0].Tittle;
                viewModal.storyMapsSubtitle_1_1 = storyMapsArray[0].Subtitle_1;
                viewModal.storyMapsSubtitle_2_1 = storyMapsArray[0].Subtitle_2;
                viewModal.storyMapsVideoPath_1 = storyMapsArray[0].VideoPath;
                viewModal.storyMapsFilePath_1 = storyMapsArray[0].FilePath;
            }
            if (null != storyMapsArray[1])
            {
                viewModal.storyMapsName_2 = storyMapsArray[1].Name;
                viewModal.storyMapsNumber_2 = storyMapsArray[1].Number;
                viewModal.storyMapsTittle_2 = storyMapsArray[1].Tittle;
                viewModal.storyMapsSubtitle_1_2 = storyMapsArray[1].Subtitle_1;
                viewModal.storyMapsSubtitle_2_2 = storyMapsArray[1].Subtitle_2;
                viewModal.storyMapsVideoPath_2 = storyMapsArray[1].VideoPath;
                viewModal.storyMapsFilePath_2 = storyMapsArray[1].FilePath;
            }
            if (null != storyMapsArray[2])
            {
                viewModal.storyMapsName_3 = storyMapsArray[2].Name;
                viewModal.storyMapsNumber_3 = storyMapsArray[2].Number;
                viewModal.storyMapsTittle_3 = storyMapsArray[2].Tittle;
                viewModal.storyMapsSubtitle_1_3 = storyMapsArray[2].Subtitle_1;
                viewModal.storyMapsSubtitle_2_3 = storyMapsArray[2].Subtitle_2;
                viewModal.storyMapsVideoPath_3 = storyMapsArray[2].VideoPath;
                viewModal.storyMapsFilePath_3 = storyMapsArray[2].FilePath;
            }
            if (null != storyMapsArray[3])
            {
                viewModal.storyMapsName_4 = storyMapsArray[3].Name;
                viewModal.storyMapsNumber_4 = storyMapsArray[3].Number;
                viewModal.storyMapsTittle_4 = storyMapsArray[3].Tittle;
                viewModal.storyMapsSubtitle_1_4 = storyMapsArray[3].Subtitle_1;
                viewModal.storyMapsSubtitle_2_4 = storyMapsArray[3].Subtitle_2;
                viewModal.storyMapsVideoPath_4 = storyMapsArray[3].VideoPath;
                viewModal.storyMapsFilePath_4 = storyMapsArray[3].FilePath;
            }
            if (null != storyMapsArray[4])
            {
                viewModal.storyMapsName_5 = storyMapsArray[4].Name;
                viewModal.storyMapsNumber_5 = storyMapsArray[4].Number;
                viewModal.storyMapsTittle_5 = storyMapsArray[4].Tittle;
                viewModal.storyMapsSubtitle_1_5 = storyMapsArray[4].Subtitle_1;
                viewModal.storyMapsSubtitle_2_5 = storyMapsArray[4].Subtitle_2;
                viewModal.storyMapsVideoPath_5 = storyMapsArray[4].VideoPath;
                viewModal.storyMapsFilePath_5 = storyMapsArray[4].FilePath;
            }
            if (null != storyMapsArray[5])
            {
                viewModal.storyMapsName_6 = storyMapsArray[5].Name;
                viewModal.storyMapsNumber_6 = storyMapsArray[5].Number;
                viewModal.storyMapsTittle_6 = storyMapsArray[5].Tittle;
                viewModal.storyMapsSubtitle_1_6 = storyMapsArray[5].Subtitle_1;
                viewModal.storyMapsSubtitle_2_6 = storyMapsArray[5].Subtitle_2;
                viewModal.storyMapsVideoPath_6 = storyMapsArray[5].VideoPath;
                viewModal.storyMapsFilePath_6 = storyMapsArray[5].FilePath;
            }
            if (null != storyMapsArray[6])
            {
                viewModal.storyMapsName_7 = storyMapsArray[6].Name;
                viewModal.storyMapsNumber_7 = storyMapsArray[6].Number;
                viewModal.storyMapsTittle_7 = storyMapsArray[6].Tittle;
                viewModal.storyMapsSubtitle_1_7 = storyMapsArray[6].Subtitle_1;
                viewModal.storyMapsSubtitle_2_7 = storyMapsArray[6].Subtitle_2;
                viewModal.storyMapsVideoPath_7 = storyMapsArray[6].VideoPath;
                viewModal.storyMapsFilePath_7 = storyMapsArray[6].FilePath;
            }
            if (null != storyMapsArray[7])
            {
                viewModal.storyMapsName_8 = storyMapsArray[7].Name;
                viewModal.storyMapsNumber_8 = storyMapsArray[7].Number;
                viewModal.storyMapsTittle_8 = storyMapsArray[7].Tittle;
                viewModal.storyMapsSubtitle_1_8 = storyMapsArray[7].Subtitle_1;
                viewModal.storyMapsSubtitle_2_8 = storyMapsArray[7].Subtitle_2;
                viewModal.storyMapsVideoPath_8 = storyMapsArray[7].VideoPath;
                viewModal.storyMapsFilePath_8 = storyMapsArray[7].FilePath;
            }
            if (null != storyMapsArray[8])
            {
                viewModal.storyMapsName_9 = storyMapsArray[8].Name;
                viewModal.storyMapsNumber_9 = storyMapsArray[8].Number;
                viewModal.storyMapsTittle_9 = storyMapsArray[8].Tittle;
                viewModal.storyMapsSubtitle_1_9 = storyMapsArray[8].Subtitle_1;
                viewModal.storyMapsSubtitle_2_9 = storyMapsArray[8].Subtitle_2;
                viewModal.storyMapsVideoPath_9 = storyMapsArray[8].VideoPath;
                viewModal.storyMapsFilePath_9 = storyMapsArray[8].FilePath;
            }
            if (null != storyMapsArray[9])
            {
                viewModal.storyMapsName_10 = storyMapsArray[9].Name;
                viewModal.storyMapsNumber_10 = storyMapsArray[9].Number;
                viewModal.storyMapsTittle_10 = storyMapsArray[9].Tittle;
                viewModal.storyMapsSubtitle_1_10 = storyMapsArray[9].Subtitle_1;
                viewModal.storyMapsSubtitle_2_10 = storyMapsArray[9].Subtitle_2;
                viewModal.storyMapsVideoPath_10 = storyMapsArray[9].VideoPath;
                viewModal.storyMapsFilePath_10 = storyMapsArray[9].FilePath;
            }
            #endregion

            if (null != userTask)
            {
                foreach (var item in userTask?.Items)
                {
                    var storyItem = new UserTaskItemViewModel
                    {
                        name = item.Name,
                        tittle = item.Tittle
                    };

                    foreach (var paragraph in item.Paragraphs)
                    {
                        var paragraphItem = new UserTaskParagraphViewModel
                        {
                            tittle = paragraph.Tittle,
                            subtittle = paragraph.Subtittle
                        };

                        foreach (var file in paragraph.UserTaskFiles)
                        {
                            var fileItem = new FileViewModel
                            {
                                name = file.Name,
                                path = file.Path,
                            };

                            paragraphItem.files.Add(fileItem);
                        }

                        foreach (var link in paragraph.UserTaskLinks)
                        {
                            var linkItem = new UserTaskLinksViewModel
                            {
                                name = link.Name,
                                link = link.Link,
                                icon = link.Icon,
                            };

                            paragraphItem.links.Add(linkItem);
                        }

                        storyItem.paragraphs.Add(paragraphItem);
                    }
                    viewModal.userTaskItems.Add(storyItem);
                }
            }
            
            ///Contact
            if(null != data.Contact?.Items)
            {
                foreach (var item in data.Contact.Items.Where(c => c.UserTypeId == userType.Id))
                {
                    var contactItem = new ContactItemViewModel
                    {
                        tittle = item.Tittle,
                        text = item.Text,
                        phoneName = item.PhoneName,
                        phoneNumber = item.PhoneNumber,
                        email = item.Email
                    };

                    viewModal.contactItems.Add(contactItem);
                }
            }
            ///Session
            string sessionId = HttpContext.Session.Id;
            var todayDate = DateTime.Now.Date;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserType")))
            {
                HttpContext.Session.SetString("UserType", userTypesTittle);
            }

            var userStatistic = _context.UserStatistics.FirstOrDefault(s => s.SessionId == sessionId && s.CreatedDate == todayDate);//
            if (null == userStatistic)
            {
                var useStatictic = new UserStatistic
                {
                    SessionId = sessionId,
                    UserType = userTypesTittle,
                    CompanyName = data.Name,
                    CreatedDate = todayDate,
                };
                _context.UserStatistics.Add(useStatictic);
                _context.SaveChanges();
            }

            return View(viewModal);
        }
    }
}
