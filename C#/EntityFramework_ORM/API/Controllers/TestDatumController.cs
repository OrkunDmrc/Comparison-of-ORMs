using API.Models.TerritoryModels;
using BLL.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class TestDatumController : ControllerBase
    {
        private readonly TestDatumService _service;
        public TestDatumController(TestDatumService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
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
