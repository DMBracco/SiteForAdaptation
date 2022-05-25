using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class UserTaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tittle { get; set; }

        public int UserTaskId { get; set; }
        public UserTask UserTask { get; set; }

        public List<UserTaskParagraph> Paragraphs { get; set; } = new List<UserTaskParagraph>();
    }
}
