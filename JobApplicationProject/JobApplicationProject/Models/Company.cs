using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationProject.Models
{
    public class Company
    {

        public int Id { get; set; }

        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        public string CompanyImage { get; set; } = "";

        public string Website { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactInfo { get; set; } = string.Empty;

        //Navigation Properties

        public List<Job>? Jobs { get; set; }


    }
}
