namespace JobApplicationProject.Models
{
    public class ApplicationStatus
    {

        public int Id { get; set; } 

        public string StatusName { get; set; } = string.Empty;

        //Navigation Properties

        public List<Job>? Jobs { get; set; }



    }
}
