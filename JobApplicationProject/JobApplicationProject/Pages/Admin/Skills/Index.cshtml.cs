using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.Services;
using swaggertest.ViewModels;

namespace JobApplicationProject.Pages.Admin.Skills
{
    public class IndexModel : PageModel
    {
        public SkillService skillService;
        public AppDbContext appDbContext;

        public List<SkillViewVM> Skills = new List<SkillViewVM>();

        public IndexModel(SkillService skillService, AppDbContext appDbContext)
        {
            this.skillService = skillService;
            this.appDbContext = appDbContext;
        }

        public void OnGet()
        {
            Skills = skillService.GetSkillsWithJobs();
        }
    }
}
