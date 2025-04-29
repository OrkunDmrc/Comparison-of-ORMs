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
        public async Task<IActionResult> GetAsync()
        {
            try
            {   
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
