namespace SiteForAdaptation.Data.Entities
{
    public class UserTaskFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int UserTaskParagraphId { get; set; }
        public UserTaskParagraph UserTaskParagraph { get; set; }
    }
}
