using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobApplicationProject.Pages.Admin.Companies
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
                Response.Redirect("/Admin/Companies/Index");
                return;
            }

            var company = context.Companies.Find(id);

            if (company == null)
            {
                Response.Redirect("/Admin/Companies/Index");
                return;
            }

            context.Companies.Remove(company);
            context.SaveChanges();

            Response.Redirect("/Admin/Companies/Index");

        }
    }
}
