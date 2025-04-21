using API.Models.SupplierModels;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService _service;
        public SupplierController(SupplierService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(new GetSupplierModel()
                {
                    SupplierID = entity.SupplierID,
                    CompanyName = entity.CompanyName,
                    ContactName = entity.ContactName,
                    ContactTitle = entity.ContactTitle,
                    Address = entity.Address,
                    City = entity.City,
                    Region = entity.Region,
                    PostalCode = entity.PostalCode,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    Fax = entity.Fax,
                    HomePage = entity.HomePage,
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
                return Ok(entities.Select(entity => new GetSupplierModel()
                {
                    SupplierID = entity.SupplierID,
                    CompanyName = entity.CompanyName,
                    ContactName = entity.ContactName,
                    ContactTitle = entity.ContactTitle,
                    Address = entity.Address,
                    City = entity.City,
                    Region = entity.Region,
                    PostalCode = entity.PostalCode,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    Fax = entity.Fax,
                    HomePage = entity.HomePage,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Add(AddSupplierModel body)
        {
            try
            {
                return Ok(_service.Add(new Supplier
                {
                    CompanyName = body.CompanyName,
                    ContactName = body.ContactName,
                    ContactTitle = body.ContactTitle,
                    Address = body.Address,
                    City = body.City,
                    Region = body.Region,
                    PostalCode = body.PostalCode,
                    Country = body.Country,
                    Phone = body.Phone,
                    Fax = body.Fax,
                    HomePage = body.HomePage,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateSupplierModel body)
        {
            try
            {
                return Ok(_service.Update(new Supplier
                {
                    SupplierID = id,
                    CompanyName = body.CompanyName,
                    ContactName = body.ContactName,
                    ContactTitle = body.ContactTitle,
                    Address = body.Address,
                    City = body.City,
                    Region = body.Region,
                    PostalCode = body.PostalCode,
                    Country = body.Country,
                    Phone = body.Phone,
                    Fax = body.Fax,
                    HomePage = body.HomePage,
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
