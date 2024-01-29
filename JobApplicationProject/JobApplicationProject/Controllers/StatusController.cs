using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swaggertest.Services;
using swaggertest.ViewModels;

namespace swaggertest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private StatusService statusService;

        public StatusController(StatusService statusService)
        {
            this.statusService = statusService;
        }

        [HttpPost("add-skill")]
        public IActionResult AddCompany([FromBody] StatusVM status)
        {
            statusService.AddStatus(status);
            return Ok();
        }

    }
}
