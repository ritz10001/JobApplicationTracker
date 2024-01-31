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

            var product = context.Jobs.Find(id);

            if(product == null)
            {
                Response.Redirect("/Admin/Jobs/Index");
                return;
            }

            context.Jobs.Remove(product);
            context.SaveChanges();

            Response.Redirect("/Admin/Jobs/Index");

        }
    }
}
