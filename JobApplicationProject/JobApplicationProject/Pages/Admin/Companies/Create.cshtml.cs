using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Companies
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        [BindProperty]
        public CompanyVM CompanyVM { get; set; } = new CompanyVM();

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

            string newImageFile = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newImageFile += Path.GetExtension(CompanyVM.CompanyImage!.FileName);

            string fullPath = environment.WebRootPath + "/Images/" + newImageFile;
            using(var stream = System.IO.File.Create(fullPath))
            {
                CompanyVM.CompanyImage.CopyTo(stream);
            }

            Company company = new Company()
            {
                CompanyName = CompanyVM.CompanyName,
                CompanyImage = newImageFile,
                ContactInfo = CompanyVM.ContactInfo,
                Website = CompanyVM.Website,
            };

            context.Companies.Add(company);
            context.SaveChanges();

            CompanyVM.CompanyName = "";
            CompanyVM.CompanyImage = null;
            CompanyVM.Website = "";
            CompanyVM.ContactInfo = "";
            

            ModelState.Clear();

            successMessage = "Company Created Successfully!";

            Response.Redirect("/Admin/Companies/Index");

        }
        
    }
}
