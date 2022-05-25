using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        public Opening Opening { get; set; }

        public List<UserTask> UserTasks { get; set; } = new List<UserTask>();

        public List<ContactItem> ContactItems { get; set; } = new List<ContactItem>();

        public List<StoryMap> StoryMaps { get; set; } = new List<StoryMap>();
    }
}
