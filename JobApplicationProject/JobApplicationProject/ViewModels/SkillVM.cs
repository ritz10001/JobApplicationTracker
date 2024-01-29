using JobApplicationProject.Models;
using System.Collections;

namespace swaggertest.ViewModels
{
    public class SkillVM
    {

        public string SkillName { get; set; } = string.Empty;

        public int YearsOfExperience { get; set; }

    }

    public class SkillWithJobsVM
    {
        public string SkillName { get; set; }

        public List<string> SkillJobs { get; set; }


        
    }
}
