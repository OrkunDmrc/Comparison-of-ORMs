using API.Models.TerritoryModels;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Territories")]
    public class TerritoryController : ControllerBase
    {
        private readonly TerritoryService _service;
        public TerritoryController(TerritoryService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                return Ok(new GetTerritoryModel()
                {
                    TerritoryID = entity.TerritoryID,
                    TerritoryDescription = entity.TerritoryDescription,
                    RegionID = entity.RegionID,
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
                return Ok(entities.Select(entity => new GetTerritoryModel()
                {
                    TerritoryID = entity.TerritoryID,
                    TerritoryDescription = entity.TerritoryDescription,
                    RegionID = entity.RegionID,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTerritoryModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Territory
                {
                    TerritoryDescription = body.TerritoryDescription,
                    RegionID = body.RegionID,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateTerritoryModel body)
        {
            try
            {
                await _service.UpdateAsync(new Territory
                {
                    TerritoryID = id,
                    TerritoryDescription = body.TerritoryDescription,
                    RegionID = body.RegionID,
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
