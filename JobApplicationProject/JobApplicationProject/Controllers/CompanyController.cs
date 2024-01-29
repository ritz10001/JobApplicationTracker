using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swaggertest.Services;
using swaggertest.ViewModels;

namespace swaggertest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private CompanyService companyService;

        public CompanyController(CompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpPost("add-company")]
        public IActionResult AddCompany([FromBody]CompanyVM company)
        {
            companyService.AddCompany(company);
            return Ok();
        }

        [HttpDelete("delete-company/{id}")]
        public IActionResult RemoveCompany(int id) { 
            companyService.RemoveCompany(id);
            return Ok();
        }

        [HttpGet("get-all-companies")]
        public IActionResult GetAllCompanies() {
            var response = companyService.GetAllCompanies();
            return Ok(response);
        }

        [HttpGet("get-company-by-id/{id}")]
        public IActionResult GetCompanyByID(int id) {
            var response = companyService.GetCompanyByID(id);
            return Ok(response);
        }

        [HttpPut("edit-company/{id}")]
        public IActionResult EditCompany([FromBody]CompanyVM company ,int id) {
            companyService.EditCompany(company, id);
            return Ok();
        }
    }
}
