namespace JobApplicationProject.Models
{
    public class Job
    {

        public int Id { get; set; } 

        public string JobName { get; set; } = string.Empty;

        public DateTime? DateApplied { get; set; }

        public string JobDescription { get; set; } = string.Empty;

        public string JobURL { get; set; } = string.Empty;

        //Navigation Properties and Classes

        public int CompanyId { get; set; }

        public string? CompanyImage { get; set; } = "...";

        public Company Company { get; set; }    

        public int? ApplicationStatusId { get; set; }

        public ApplicationStatus ApplicationStatus { get; set; }

        public List<Job_Skill> Job_Skills { get; set; }   

    }
}
