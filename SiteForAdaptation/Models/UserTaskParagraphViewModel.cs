using System.Collections.Generic;

namespace SiteForAdaptation.Models
{
    public class UserTaskParagraphViewModel
    {
        public string tittle { get; set; }
        public string subtittle { get; set; }

        public List<FileViewModel> files { get; set; } = new List<FileViewModel>();
        public List<UserTaskLinksViewModel> links { get; set; } = new List<UserTaskLinksViewModel>();
    }

    public class FileViewModel
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class UserTaskLinksViewModel
    {
        public string name { get; set; }
        public string link { get; set; }
        public string icon { get; set; }
    }
}
