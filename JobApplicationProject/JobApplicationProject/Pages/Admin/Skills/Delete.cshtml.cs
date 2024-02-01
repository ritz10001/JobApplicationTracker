using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobApplicationProject.Pages.Admin.Skills
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        public DeleteModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

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

            context.Skills.Remove(skill);
            context.SaveChanges();

            Response.Redirect("/Admin/Skills/Index");
        }
    }
}
