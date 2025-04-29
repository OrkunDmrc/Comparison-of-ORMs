using API.Models.CategoyModels;
using API.Models.CustomerModels;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;
        public CustomerController(CustomerService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                return Ok(new GetCustomerModel()
                {
                    CustomerID = entity.CustomerID,
                    CompanyName = entity.CompanyName,
                    ContactName = entity.ContactName,
                    ContactTitle = entity.ContactTitle,
                    Address = entity.Address,
                    City = entity.City,
                    Region = entity.Region,
                    PostalCode = entity.PostalCode,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    Fax = entity.Fax
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
                return Ok(entities.Select(entity => new GetCustomerModel()
                {
                    CustomerID = entity.CustomerID,
                    CompanyName = entity.CompanyName,
                    ContactName = entity.ContactName,
                    ContactTitle = entity.ContactTitle,
                    Address = entity.Address,
                    City = entity.City,
                    Region = entity.Region,
                    PostalCode = entity.PostalCode,
                    Country = entity.Country,
                    Phone = entity.Phone,
                    Fax = entity.Fax
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Customer
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
                    Fax = body.Fax
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateCustomerModel body)
        {
            try
            {
                await _service.UpdateAsync(new Customer
                {
                    CustomerID = id,
                    CompanyName = body.CompanyName,
                    ContactName = body.ContactName,
                    ContactTitle = body.ContactTitle,
                    Address = body.Address,
                    City = body.City,
                    Region = body.Region,
                    PostalCode = body.PostalCode,
                    Country = body.Country,
                    Phone = body.Phone,
                    Fax = body.Fax
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
