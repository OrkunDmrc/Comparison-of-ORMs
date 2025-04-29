using API.Models.ShipperModels;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ShipperController : ControllerBase
    {
        private readonly ShipperService _service;
        public ShipperController(ShipperService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                return Ok(new GetShipperModel()
                {
                    ShipperID = entity.ShipperID,
                    CompanyName = entity.CompanyName,
                    Phone = entity.Phone,
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
                return Ok(entities.Select(entity => new GetShipperModel()
                {
                    ShipperID = entity.ShipperID,
                    CompanyName = entity.CompanyName,
                    Phone = entity.Phone,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddShipperModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Shipper
                {
                    CompanyName = body.CompanyName,
                    Phone = body.Phone,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateShipperModel body)
        {
            try
            {
                await _service.UpdateAsync(new Shipper
                {
                    ShipperID = id,
                    CompanyName = body.CompanyName,
                    Phone = body.Phone,
                });
                return Ok();
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
