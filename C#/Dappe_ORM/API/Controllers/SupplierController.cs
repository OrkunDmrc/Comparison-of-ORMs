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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.GetAllAsync();
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
        public async Task<IActionResult> Add(AddSupplierModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Supplier
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
        public async Task<IActionResult> Update(int id, UpdateSupplierModel body)
        {
            try
            {
                return Ok(await _service.UpdateAsync(new Supplier
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
