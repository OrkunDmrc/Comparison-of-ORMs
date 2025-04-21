using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("TestData")]
    public class TestDatumController : ControllerBase
    {
        private readonly TestDatumService _service;
        public TestDatumController(TestDatumService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {   
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
