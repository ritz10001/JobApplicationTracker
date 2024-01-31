using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.ViewModels;
using System.ComponentModel.Design;

namespace JobApplicationProject.Pages.Admin.Jobs
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        [BindProperty]
        public JobVM JobVM { get; set; } = new JobVM();

        public Job Job { get; set; } = new Job();

        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            var job = context.Jobs.Find(id);

            if (job == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            JobVM.JobName = job.JobName;
            JobVM.JobDescription = job.JobDescription;
            JobVM.JobURL = job.JobURL;
            JobVM.CompanyId = job.CompanyId;
            JobVM.ApplicationStatusId = job.ApplicationStatusId;

            //foreach (var skill in JobVM.SkillIds)
            //{
            //    var job_skill = new Job_Skill()
            //    {
            //        JobId = job.Id,
            //        SkillId = skill
            //    };
            //    context.SaveChanges();
            //}

            Job = job;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please fill up the requried fields!";
                return;
            }

            var job = context.Jobs.Find(id);
            if (job == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            

            job.JobName = JobVM.JobName;
            job.JobDescription = JobVM.JobDescription;
            job.JobURL = JobVM.JobURL;
            job.CompanyId = JobVM.CompanyId;
            job.ApplicationStatusId = JobVM.ApplicationStatusId;

            //foreach (var skill in job.Job_Skills)
            //{
            //    var job_skill = new Job_Skill()
            //    {
            //        JobId = job.Id,
            //        SkillId = skill.SkillId
            //    };
            //    context.SaveChanges();
            //}

            context.SaveChanges();

            Job = job;
            successMessage = "Job updated successfully!";

            Response.Redirect("/Admin/Jobs/Index");

        }
    }
}
