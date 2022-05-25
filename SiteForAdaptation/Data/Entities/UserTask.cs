using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Subtittle { get; set; }
        public string Text { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public List<UserTaskItem> Items { get; set; } = new List<UserTaskItem>();
    }
}
