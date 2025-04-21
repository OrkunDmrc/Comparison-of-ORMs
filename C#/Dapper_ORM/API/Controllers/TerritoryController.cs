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
        public IActionResult Get(string id)
        {
            try
            {
                var entity = _service.GetById(id);
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
        public IActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
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
        public IActionResult Add(AddTerritoryModel body)
        {
            try
            {
                return Ok(_service.Add(new Territory
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
        public IActionResult Update(string id, UpdateTerritoryModel body)
        {
            try
            {
                return Ok(_service.Update(new Territory
                {
                    TerritoryID = id,
                    TerritoryDescription = body.TerritoryDescription,
                    RegionID = body.RegionID,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
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
