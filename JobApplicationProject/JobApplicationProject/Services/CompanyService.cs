using JobApplicationProject;
using JobApplicationProject.Models;
using swaggertest.ViewModels;

namespace swaggertest.Services
{
    public class CompanyService
    {

        private AppDbContext context;

        public CompanyService(AppDbContext context)
        {

            this.context = context;

        }

        public void AddCompany(CompanyVM company)
        {
            var _company = new Company()
            {
                CompanyName = company.CompanyName,
                CompanyImage = company.CompanyImage,
                Website = company.Website,
                ContactInfo = company.ContactInfo
            };
            context.Companies.Add(_company);
            context.SaveChanges();
        }

        public void RemoveCompany(int id)
        {
            var company = context.Companies.Find(id);

            if (company != null)
            {
                context.Companies.Remove(company);
                context.SaveChanges();
            }
        }

        public void EditCompany(CompanyVM company, int id)
        {
            var _company = context.Companies.Find(id);

            if(_company != null)
            {
                _company.CompanyName = company.CompanyName;
                _company.CompanyImage = company.CompanyImage;
                _company.Website = company.Website;
                _company.ContactInfo = company.ContactInfo;
            }

            context.SaveChanges();
            

        }


        public List<CompanyViewVM> GetAllCompanies()
        {
            var companies = context.Companies.Select(company => new CompanyViewVM
            {
                CompanyId = company.Id,
                CompanyName = company.CompanyName,
                CompanyImage = company.CompanyImage,
                Website = company.Website,
                ContactInfo = company.ContactInfo
            }).ToList();

            return companies;
        }

        public CompanyViewVM GetCompanyByID(int id)
        {
            var _company = context.Companies.Where(company => company.Id == id).Select(company => new 
            CompanyViewVM
            {
                CompanyName = company.CompanyName,
                CompanyImage = company.CompanyImage,
                Website = company.Website,
                ContactInfo = company.ContactInfo,
            }).FirstOrDefault();

            return _company;
        }


    }
}
