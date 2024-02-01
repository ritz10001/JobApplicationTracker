using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Skills
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        [BindProperty]
        public SkillVM SkillVM { get; set; } = new SkillVM();

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

            Skill skill = new Skill()
            {
                SkillName = SkillVM.SkillName,
                YearsOfExperience = SkillVM.YearsOfExperience,

            };

            context.Skills.Add(skill);
            context.SaveChanges();

            SkillVM.SkillName = "";
            SkillVM.YearsOfExperience = 0;

            ModelState.Clear();

            successMessage = "Skill Created Successfully!";

            Response.Redirect("/Admin/Skills/Index");

        }


    }
}
