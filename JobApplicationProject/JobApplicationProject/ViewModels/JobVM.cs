using JobApplicationProject.Models;

namespace swaggertest.ViewModels
{
    public class JobVM
    {

        public string JobName { get; set; } = string.Empty;

        public DateTime? DateApplied { get; set; }

        public string JobDescription { get; set; } = string.Empty;

        public string JobURL { get; set; } = string.Empty;

        public int CompanyId { get; set; }

        public int? ApplicationStatusId { get; set; } 

        public List<int> SkillIds { get; set; }

    }

    public class JobInfoVM
    {
        public int JobId { get; set; }

        public string JobName { get; set; } = string.Empty;

        public DateTime? DateApplied { get; set; }

        public string JobDescription { get; set; } = string.Empty;

        public string JobURL { get; set; } = string.Empty;

        public int CompanyId { get; set; }

        public int? ApplicationStatusId { get; set; }

        //public List<int> SkillIds { get; set; }

        public string Company { get; set; }

        public string ApplicationStatus { get; set; }   

        public List<string> JobSkills { get; set; }

    }
}
