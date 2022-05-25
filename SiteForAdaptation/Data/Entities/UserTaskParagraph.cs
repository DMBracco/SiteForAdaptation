using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class UserTaskParagraph
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Subtittle { get; set; }

        public int UserTaskItemId { get; set; }
        public UserTaskItem UserTaskItem { get; set; }

        public List<UserTaskFile> UserTaskFiles { get; set; } = new List<UserTaskFile>();

        public List<UserTaskLink> UserTaskLinks { get; set; } = new List<UserTaskLink>();
    }
}
