using System.Collections.Generic;

namespace SiteForAdaptation.Data.Entities
{
    public class MemoForManager
    {
        public int Id { get; set; }

        public string Tittle_1 { get; set; }
        public string Subtittle_1 { get; set; }

        public string Tittle_2 { get; set; }
        public string Subtittle_2 { get; set; }

        public string Tittle_3 { get; set; }
        public string Subtittle_3 { get; set; }

        public string Tittle_4 { get; set; }
        public string Subtittle_4 { get; set; }

        public string Tittle_5 { get; set; }
        public string Subtittle_5 { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        //public List<MemoForManagerItem> Items { get; set; }
    }
}
