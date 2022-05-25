using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class StoryMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public string Tittle { get; set; }
        public string Subtitle_1 { get; set; }
        public string Subtitle_2 { get; set; }

        //public string ImageName { get; set; }
        //public string ImagePath { get; set; }

        //public string VideoName { get; set; }
        public string VideoPath { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        //public List<StoryItem> StoryItems { get; set; }
    }
}
