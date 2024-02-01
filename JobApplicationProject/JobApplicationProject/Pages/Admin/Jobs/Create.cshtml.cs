using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        [BindProperty]
        public JobVM JobVM { get; set; } = new JobVM();

        public CreateModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Please enter the required fields!";
                return;
            }

            Job job = new Job()
            {
                JobName = JobVM.JobName,
                JobDescription = JobVM.JobDescription,
                JobURL = JobVM.JobURL,
                CompanyId = JobVM.CompanyId,
                ApplicationStatusId = JobVM.ApplicationStatusId,
                
            };

            context.Jobs.Add(job);
            context.SaveChanges();

            if (JobVM.SkillIds != null)
            {
                foreach (var skillid in JobVM.SkillIds)
                {
                    var job_skill = new Job_Skill()
                    {
                        JobId = job.Id,
                        SkillId = skillid
                    };
                    context.Job_Skills.Add(job_skill);
                    context.SaveChanges();
                }
            }
            

            JobVM.JobName = "";
            JobVM.DateApplied = DateTime.Now;
            JobVM.JobDescription = "";
            JobVM.JobURL = "";
            JobVM.CompanyId = 0;
            JobVM.ApplicationStatusId = 0;
            JobVM.SkillIds = new List<int>();

            ModelState.Clear();

            successMessage = "Job Created Successfully!";

            Response.Redirect("/Admin/Jobs/Index");

        }
    }
}
