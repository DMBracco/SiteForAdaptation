namespace SiteForAdaptation.Data.Entities
{
    public class ContactItem
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }

        public string PhoneName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
