namespace JobApplicationProject.Models
{
    public class Job_Skill
    {

        public int Id { get; set; }

        //Junction/Join Table
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int SkillId { get; set; }   

        public Skill Skill {  get; set; }





    }
}
