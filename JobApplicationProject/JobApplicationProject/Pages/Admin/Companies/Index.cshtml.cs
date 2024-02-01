using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.Services;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Companies
{
    public class IndexModel : PageModel
    {

        public CompanyService companyService;
        public AppDbContext appDbContext;

        public List<CompanyViewVM> Companies = new List<CompanyViewVM>();

        public IndexModel(CompanyService companyService, AppDbContext appDbContext)
        {
            this.companyService = companyService;
            this.appDbContext = appDbContext;
        }



        public void OnGet()
        {
            Companies = companyService.GetAllCompanies();
        }
    }
}
