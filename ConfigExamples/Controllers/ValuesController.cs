using ConfigExamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly IOptions<AppsettingsModel> Appsettings;
        public ValuesController(IConfiguration configuration, IOptions<AppsettingsModel> app) 
        {
            Configuration = configuration;
            Appsettings = app;
        }

        [HttpGet("Test1")]
        public IActionResult GetTest1()
        {
            string val = Configuration.GetSection("Values").GetSection("Test1").Value;

            return Ok(val);
        }

        [HttpGet("Test2")]
        public IActionResult GetTest2()
        {
            string val = Configuration.GetValue<string>("Values:Test2");
            
            return Ok(val);
        }

        [HttpGet("Test3")]
        public IActionResult GetTest3()
        {
            string val = Appsettings.Value.Test1;

            return Ok(val);
        }
    }
}
