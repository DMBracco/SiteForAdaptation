using System;
using System.ComponentModel.DataAnnotations;

namespace SiteForAdaptation.Data.Entities
{
    public class UserStatistic
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string UserType { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string CompanyName { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}
