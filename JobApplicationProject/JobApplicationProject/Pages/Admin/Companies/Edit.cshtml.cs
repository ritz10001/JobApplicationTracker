using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Companies
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

        public CompanyVM CompanyVM { get; set; } = new CompanyVM();

        public Company Company { get; set; } = new Company();

        public string errorMessage = "";
        public string successMessage = "";


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

            CompanyVM.CompanyName = company.CompanyName;
            CompanyVM.CompanyImage = company.CompanyImage;
            CompanyVM.Website = company.Website;
            CompanyVM.ContactInfo = company.ContactInfo;

            Company = company;
        }

        public void OnPost(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Admin/Companies/Index");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please fill up the requried fields!";
                return;
            }

            var company = context.Companies.Find(id);
            if(company == null) {

                Response.Redirect("/Admin/Companies/Index");
                return;

            }

            company.CompanyName = CompanyVM.CompanyName;
            company.CompanyImage = CompanyVM.CompanyImage;
            company.Website = CompanyVM.Website;    
            company.ContactInfo = company.ContactInfo;

            context.SaveChanges();

            Company = company;
            successMessage = "Company Updated Successfully";

            Response.Redirect("/Admin/Companies/Index");

        }
    }
}
