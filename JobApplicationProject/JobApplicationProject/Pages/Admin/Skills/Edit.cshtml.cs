using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Skills
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        public EditModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            this.context = context;

        }

        public SkillVM SkillVM { get; set; } = new SkillVM();

        public Skill Skill { get; set; } = new Skill();

        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Skills/Index");
                return;
            }

            var skill = context.Skills.Find(id);

            if (skill == null)
            {
                Response.Redirect("/Admin/Skills/Index");
                return;
            }

            SkillVM.SkillName = skill.SkillName;
            SkillVM.YearsOfExperience = skill.YearsOfExperience;

            Skill = skill;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Skills/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please fill up the requried fields!";
                return;
            }

            var skill = context.Skills.Find(id);
            if (skill == null)
            {

                Response.Redirect("/Admin/Skills/Index");
                return;

            }

            skill.SkillName = SkillVM.SkillName;
            skill.YearsOfExperience = SkillVM.YearsOfExperience;


            context.SaveChanges();

            Skill = skill;
            successMessage = "Skill Updated Successfully";

            Response.Redirect("/Admin/Skill/Index");

        }
    }
}
