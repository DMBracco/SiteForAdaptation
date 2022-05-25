namespace SiteForAdaptation.Data.Entities
{
    public class UserTaskLink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }

        public int UserTaskParagraphId { get; set; }
        public UserTaskParagraph UserTaskParagraph { get; set; }
    }
}
