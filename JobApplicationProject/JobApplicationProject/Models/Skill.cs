namespace JobApplicationProject.Models
{
    public class Skill
    {

        public int Id { get; set; }

        public string SkillName { get; set; } = string.Empty;

        public int YearsOfExperience { get; set;}

        //Navigation Properties
        public List<Job_Skill>? Job_Skills { get; set; }

    }
}
