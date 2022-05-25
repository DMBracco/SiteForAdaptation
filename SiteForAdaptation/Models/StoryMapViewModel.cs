using System.Collections.Generic;

namespace SiteForAdaptation.Models
{
    public class StoryMapViewModel
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public string Tittle { get; set; }
        public string Subtitle_1 { get; set; }
        public string Subtitle_2 { get; set; }

        //public string storyImagePath { get; set; }
        public string VideoPath { get; set; }
        public string FilePath { get; set; }

        //public List<StoryItemViewModel> storyItems { get; set; } = new List<StoryItemViewModel>();
    }

    public class StoryItemViewModel
    {
        public string storyItemTittle { get; set; }
    }
}
