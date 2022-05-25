using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sorting { get; set; }
        public bool IsHide { get; set; } = false;

        public Contact Contact { get; set; }

        public MemoForManager MemoForManager { get; set; }

        public List<UserTask> UserTasks { get; set; } = new List<UserTask>();
    }
}
