using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swaggertest.Services;
using swaggertest.ViewModels;

namespace swaggertest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private JobService jobService;

        public JobController(JobService jobService)
        {
            this.jobService = jobService;   
        }

        [HttpPost("add-job")]
        public IActionResult AddJob([FromBody] JobVM job)
        {
            jobService.AddJob(job);
            return Ok();
        }

        [HttpGet("get-all-jobs")]
        public IActionResult GetAllJobs()
        {
            var jobs = jobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("get-job-by-id")]
        public IActionResult GetJobByID(int jobId)
        {
            var job = jobService.GetJobByID(jobId);
            return Ok(job);
        }

        [HttpDelete("remove-job")]
        public IActionResult RemoveJob(int jobId) { 
            jobService.RemoveJob(jobId);
            return Ok();
        }

        
    }
}
