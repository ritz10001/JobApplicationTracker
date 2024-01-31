using JobApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using swaggertest.Services;
using swaggertest.ViewModels;
using System.Linq;

namespace JobApplicationProject.Pages.Admin.Jobs
{
    public class IndexModel : PageModel
    {
        public JobService jobService;
        public AppDbContext appDbContext;

        //Pagination
        public int pageIndex = 1;
        public int totalPages = 0;
        private readonly int pageSize = 5;

        //Search
        public string search = "";

        //sort
        public string column = "";
        public string orderBy = "";
         
        public List<JobInfoVM> Jobs { get; set; } = new List<JobInfoVM>();

        public IndexModel(JobService jobService, AppDbContext appDbContext)
        {
            this.jobService = jobService;
            this.appDbContext = appDbContext;   

        }


        public void OnGet(int? pageIndex, string? search, string? column, string? orderBy)
        {
            IQueryable<JobInfoVM> query = jobService.GetAllJobs().AsQueryable();
            //Jobs = jobService.GetAllJobs();

            //search function
            if(search != null)
            {
                this.search = search;
                query = query.Where(j => j.JobName.Contains(search) || j.Company.Contains(search));
            }

            //sort function
            string[] validColumns = { "Id", "JobName", "DateApplied", "Company" };
            string[] validOrderBy = { "desc", "asc" };

            if (!validColumns.Contains(column))
            {
                column = "Id";
            }

            if (!validColumns.Contains(orderBy))
            {
                orderBy = "desc";
            }
            this.column = column;
            this.orderBy = orderBy;

            if(column == "JobName")
            {
                if(orderBy == "asc")
                {
                    query = query.OrderBy(j => j.JobName);
                }
                else
                {
                    query = query.OrderByDescending(j => j.JobName);
                }
            }

            else if (column == "Company")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(j => j.Company);
                }
                else
                {
                    query = query.OrderByDescending(j => j.Company);
                }
            }

            else if (column == "DateApplied")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(j => j.DateApplied);
                }
                else
                {
                    query = query.OrderByDescending(j => j.DateApplied);
                }
            }

            else
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(j => j.JobId);
                }
                else
                {
                    query = query.OrderByDescending(j => j.JobId);
                }
            }
            //pagination function
            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }

            this.pageIndex = (int)pageIndex;
            decimal count = query.Count();

            totalPages = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize).Take(pageSize);
            Jobs = query.ToList();


        }
    }
}
