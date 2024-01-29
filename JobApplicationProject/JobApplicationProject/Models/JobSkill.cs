namespace JobApplicationProject.Models
{
    public class JobSkill
    {
        //Junction/Join Table
        public int JobId { get; set; }

        public required Job Job { get; set; }

        public int SkillId { get; set; }   

        public required Skill Skill {  get; set; }





    }
}
