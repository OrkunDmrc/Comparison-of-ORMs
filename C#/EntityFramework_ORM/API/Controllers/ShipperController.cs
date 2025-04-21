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
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
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
        public IActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
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
        public IActionResult Add(AddShipperModel body)
        {
            try
            {
                return Ok(_service.Add(new Shipper
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
        public IActionResult Update(int id, UpdateShipperModel body)
        {
            try
            {
                return Ok(_service.Update(new Shipper
                {
                    ShipperID = id,
                    CompanyName = body.CompanyName,
                    Phone = body.Phone,
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
