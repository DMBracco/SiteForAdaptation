namespace SiteForAdaptation.Data.Entities
{
    public class StoryItem
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        public int StoryMapId { get; set; }
        public StoryMap StoryMap { get; set; }
    }
}
