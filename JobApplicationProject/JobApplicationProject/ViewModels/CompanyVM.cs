using System.ComponentModel.DataAnnotations;

namespace swaggertest.ViewModels
{
    public class CompanyVM
    {
        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        public string CompanyImage { get; set; } = string.Empty;

        //[MaxLength(100)]
        //public string Location { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactInfo { get; set; } = string.Empty;

        public List<int> JobIds { get; set; }


    }

    public class CompanyViewVM
    {
        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        public string CompanyImage { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactInfo { get; set; } = string.Empty;

        //public List<int> JobIds { get; set; }


    }

}
