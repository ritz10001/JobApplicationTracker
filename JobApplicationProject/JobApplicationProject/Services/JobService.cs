using JobApplicationProject;
using JobApplicationProject.Models;
using swaggertest.ViewModels;

namespace swaggertest.Services
{
    public class JobService
    {

        private AppDbContext context;

        public JobService(AppDbContext context) { 
        
            this.context = context;

        }

        public void AddJob(JobVM job)
        {
            var _Job = new Job()
            {
                JobName = job.JobName,
                JobDescription = job.JobDescription,
                JobURL = job.JobURL,
                CompanyId = job.CompanyId,
                ApplicationStatusId = job.ApplicationStatusId,
               
            };

            context.Jobs.Add(_Job);
            context.SaveChanges();


            foreach(var skillid in job.SkillIds)
            {
                var job_skill = new Job_Skill()
                {
                    JobId = _Job.Id,
                    SkillId = skillid
                };
                context.Job_Skills.Add(job_skill);
                context.SaveChanges();
            }
        }

        public List<JobInfoVM> GetAllJobs()
        {

            var jobs = context.Jobs.Select(job => new JobInfoVM
            {
                JobId = job.Id,
                JobName = job.JobName,
                JobDescription = job.JobDescription,
                JobURL = job.JobURL,
                CompanyId = job.CompanyId,
                ApplicationStatusId = job.ApplicationStatusId,
                Company = job.Company.CompanyName,
                CompanyImage = job.Company.CompanyImage,
                ApplicationStatus = job.ApplicationStatus.StatusName,
                JobSkills = job.Job_Skills.Select(skill => skill.Skill.SkillName).ToList()
            }).ToList();

            return jobs;


        }

        public JobInfoVM GetJobByID(int jobId)
        {
            var _job = context.Jobs.Where(job => job.Id == jobId).Select(job => new JobInfoVM
            {
                JobName = job.JobName,
                JobDescription = job.JobDescription,
                JobURL = job.JobURL,
                CompanyId = job.CompanyId,
                CompanyImage = job.Company.CompanyImage,
                ApplicationStatusId = job.ApplicationStatusId,
                Company = job.Company.CompanyName,
                ApplicationStatus = job.ApplicationStatus.StatusName,
                JobSkills = job.Job_Skills.Select(skill => skill.Skill.SkillName).ToList()
            }).FirstOrDefault();

            return _job;
        }

        public void RemoveJob(int jobId)
        {
            var _job = context.Jobs.Find(jobId);

            if(_job != null)
            {
                context.Jobs.Remove(_job);
            }

            var _job_skill = context.Job_Skills.Find(jobId);

            if( _job_skill != null)
            {
                context.Job_Skills.Remove(_job_skill);
            }

            context.SaveChanges();

        }

    }
}
