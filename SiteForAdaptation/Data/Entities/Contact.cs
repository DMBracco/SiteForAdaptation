 using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public List<ContactItem> Items { get; set; } = new List<ContactItem>();
    }
}
