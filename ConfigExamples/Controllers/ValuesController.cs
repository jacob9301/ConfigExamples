using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ValuesController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet("Test1")]
        public IActionResult GetTest1()
        {
            string val = _configuration.GetSection("Values:Test1").Value;

            return Ok(val);
        }

        [HttpGet("Test2")]
        public IActionResult GetTest2()
        {
            string val = _configuration.GetValue<string>("Values:Test2");
            
            return Ok(val);
        }
    }
}
