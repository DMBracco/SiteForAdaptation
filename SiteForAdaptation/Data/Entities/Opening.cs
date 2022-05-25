using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteForAdaptation.Data.Entities
{
    public class Opening
    {
        public int Id { get; set; }

        //public string ImageName { get; set; }
        //public string ImagePath { get; set; }

        //public string VideoName { get; set; }
        public string VideoPath { get; set; }

        //public string FileName { get; set; }
        public string FilePath { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
