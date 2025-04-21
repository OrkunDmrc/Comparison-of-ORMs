using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using API.Models.RegionModel;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class RegionController : ControllerBase
    {
        private readonly RegionService _service;
        public RegionController(RegionService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(new GetRegionModel()
                {
                    RegionID = entity.RegionID,
                    RegionDescription = entity.RegionDescription,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities.Select(entity => new GetRegionModel()
                {
                    RegionID = entity.RegionID,
                    RegionDescription = entity.RegionDescription
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Add(AddRegionModel body)
        {
            try
            {
                return Ok(_service.Add(new Region
                {
                    RegionDescription = body.RegionDescription,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRegionModel body)
        {
            try
            {
                return Ok(_service.Update(new Region
                {
                    RegionID = id,
                    RegionDescription = body.RegionDescription,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
