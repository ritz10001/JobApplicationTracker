using JobApplicationProject;
using JobApplicationProject.Models;
using swaggertest.ViewModels;

namespace swaggertest.Services
{
    public class SkillService
    {

        private AppDbContext context;

        public SkillService(AppDbContext context)
        {

            this.context = context;

        }

        public void AddSkill(SkillVM skill)
        {
            var _skill = new Skill()
            {
                SkillName = skill.SkillName,
                YearsOfExperience = skill.YearsOfExperience
            };

            context.Skills.Add(_skill);
            context.SaveChanges();
        }

        public List<SkillViewVM> GetSkillsWithJobs() {
            var _skill = context.Skills.Select(job => new SkillViewVM
            {
                SkillId = job.Id,
                SkillName = job.SkillName,
                SkillJobs = job.Job_Skills.Select(job => job.Job.JobName).ToList()
              
            }).ToList();

            return _skill;
        }

        public SkillViewVM GetSkillsWithJobsByID(int skillId)
        {
            var _skill = context.Skills.Where(skill => skill.Id == skillId).Select(job => new SkillViewVM
            {
                SkillId = job.Id,
                SkillName = job.SkillName,
                SkillJobs = job.Job_Skills.Select(job => job.Job.JobName).ToList()
                
            }).FirstOrDefault();

            return _skill;
        }

    }
}
