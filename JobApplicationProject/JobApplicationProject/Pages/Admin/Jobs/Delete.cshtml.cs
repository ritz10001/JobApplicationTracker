using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobApplicationProject.Pages.Admin.Jobs
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

            if(id == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            var job = context.Jobs.Find(id);

            if(job == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            context.Jobs.Remove(job);
            context.SaveChanges();

            Response.Redirect("/Admin/Jobs/Index");

        }
    }
}
