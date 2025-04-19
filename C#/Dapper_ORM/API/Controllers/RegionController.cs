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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.GetAllAsync();
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
        public async Task<IActionResult> Add(AddRegionModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Region
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
        public async Task<IActionResult> Update(int id, UpdateRegionModel body)
        {
            try
            {
                return Ok(await _service.UpdateAsync(new Region
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _service.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
