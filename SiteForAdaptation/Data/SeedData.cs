using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SiteForAdaptation.Data.Entities;

namespace SiteForAdaptation.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DataContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Companies.Any())
            {
                context.Companies.AddRange(
                    new Company
                    {
                        Name = "УК НМГ",
                        Sorting = 1
                    },
                    new Company
                    {
                        Name = "СТС",
                        Sorting = 2
                    },
                    new Company
                    {
                        Name = "Домашний",
                        Sorting = 3
                    },
                    new Company
                    {
                        Name = "СТС Love",
                        Sorting = 4
                    },
                    new Company
                    {
                        Name = "СТС Kids",
                        Sorting = 5
                    },
                    new Company
                    {
                        Name = "ЧЕ!",
                        Sorting = 6
                    },
                    new Company
                    {
                        Name = "ПЯТЫЙ КАНАЛ",
                        Sorting = 7
                    },
                    new Company
                    {
                        Name = "Телеканал РЕН ТВ",
                        Sorting = 8
                    },
                    new Company
                    {
                        Name = "Телеканал «78»",
                        Sorting = 9
                    },
                    new Company
                    {
                        Name = "МИЦ «Известия»",
                        Sorting = 10
                    },
                    new Company
                    {
                        Name = "СПОРТ-ЭКСПРЕСС",
                        Sorting = 11
                    },
                    new Company
                    {
                        Name = "Деловой Петербург",
                        Sorting = 12
                    },
                    new Company
                    {
                        Name = "Медиа-Телеком",
                        Sorting = 13
                    },
                    new Company
                    {
                        Name = "НМГ Тех",
                        Sorting = 14
                    },
                    new Company
                    {
                        Name = "more.tv",
                        Sorting = 15
                    },
                    new Company
                    {
                        Name = "ЭВЕРЕСТ",
                        Sorting = 16
                    },
                    new Company
                    {
                        Name = "ВИТРИНА ТВ",
                        Sorting = 17
                    },
                    new Company
                    {
                        Name = "Медиа Бизнес Солюшенс",
                        Sorting = 18
                    },
                    new Company
                    {
                        Name = "Art Pictures Distribution",
                        Sorting = 19
                    }
                );

                context.SaveChanges();
            }

            if (!context.UserTypes.Any())
            {
                context.UserTypes.AddRange(
                    new UserType
                    {
                        Tittle = "Руководитель"
                    },
                    new UserType
                    {
                        Tittle = "Сотрудник"
                    }
                );

                context.SaveChanges();
            }

            if (!context.NavBars.Any())
            {
                context.NavBars.AddRange(
                    new NavBar
                    {
                        Title_1 = "Выбрать компанию", Link_1 = "link",
                        Title_2 = "Карта историй", Link_2 = "link",
                        Title_3 = "План адаптации", Link_3 = "link",
                        Title_4 = "Полезные контакты", Link_4 = "link",
                        Title_5 = "Вернуться на портал НМГ", Link_5 = "link",
                        UserTypeTittle = "Сотрудник"
                    },
                    new NavBar
                    {
                        Title_1 = "Выбрать компанию",
                        Link_1 = "link",
                        Title_2 = "Карта историй",
                        Link_2 = "link",
                        Title_3 = "План адаптации",
                        Link_3 = "link",
                        Title_4 = "Полезные контакты",
                        Link_4 = "link",
                        Title_5 = "Вернуться на портал НМГ",
                        Link_5 = "link",
                        UserTypeTittle = "Руководитель"
                    },
                    new NavBar
                    {
                        Title_1 = "Выбрать компанию",
                        Link_1 = "link",
                        Title_2 = "Карта историй",
                        Link_2 = "link",
                        Title_3 = "План адаптации",
                        Link_3 = "link",
                        Title_4 = "Полезные контакты",
                        Link_4 = "link",
                        Title_5 = "Вернуться на портал НМГ",
                        Link_5 = "link",
                        UserTypeTittle = "Общая"
                    }
                );

                context.SaveChanges();
            }

            if (!context.Openings.Any())
            {
                context.Openings.AddRange(
                    new Opening
                    {
                        UserTypeId = 1,
                        //VideoName = "По умолчанию",
                        VideoPath = "https://player.vimeo.com/video/698517768?h=9f4018483d"
                    },
                    new Opening
                    {
                        UserTypeId = 2,
                        //VideoName = "По умолчанию",
                        VideoPath = "https://player.vimeo.com/video/698180293?h=d104e664d9"
                    }
                );

                context.SaveChanges();
            }

            if (!context.StoryMaps.Any())
            {
                context.StoryMaps.AddRange(
                    new StoryMap
                    {
                        UserTypeId = 1,
                        Name = "Роль руководителя<br>в период адаптации",
                        Number = "01",
                        VideoPath = "https://player.vimeo.com/video/698530834?h=0d668743c7"
                    },
                    new StoryMap
                    {
                        UserTypeId = 1,
                        Name = "Наставнический стиль<br>как источник потенциала",
                        Number = "02",
                        VideoPath = "https://player.vimeo.com/video/698522783?h=dd459787c4"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
