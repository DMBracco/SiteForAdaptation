using System.Collections.Generic;

namespace SiteForAdaptation.Models
{
    public class UserTaskItemViewModel
    {
        public string name { get; set; }
        public string tittle { get; set; }

        public List<UserTaskParagraphViewModel> paragraphs { get; set; } = new List<UserTaskParagraphViewModel>();
    }
}
