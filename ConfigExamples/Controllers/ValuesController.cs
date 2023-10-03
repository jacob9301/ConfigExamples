using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public ValuesController(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        [HttpGet("Test1")]
        public IActionResult GetTest1()
        {
            string val = Configuration.GetSection("Values:Test1").Value;

            return Ok(val);
        }

        [HttpGet("Test2")]
        public IActionResult GetTest2()
        {
            string val = Configuration.GetValue<string>("Values:Test2");
            
            return Ok(val);
        }
    }
}
