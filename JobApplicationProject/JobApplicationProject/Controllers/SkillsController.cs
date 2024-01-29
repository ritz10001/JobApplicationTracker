using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swaggertest.Services;
using swaggertest.ViewModels;

namespace swaggertest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private SkillService skillService;

        public SkillsController(SkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpPost("add-skill")]
        public IActionResult AddCompany([FromBody] SkillVM skill)
        {
            skillService.AddSkill(skill);
            return Ok();
        }

        [HttpGet("get-jobs-by-skill-id/{id}")]
        public IActionResult GetJobFromSkills(int id)
        {
            var _response = skillService.GetJobFromSkills(id);
            return Ok(_response);
        }

    }
}
