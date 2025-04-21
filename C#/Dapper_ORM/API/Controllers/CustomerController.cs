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
        public IActionResult Get(string id)
        {
            try
            {
                var entity = _service.GetById(id);
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
        public IActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
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
        public IActionResult Add(AddCustomerModel body)
        {
            try
            {
                return Ok(_service.Add(new Customer
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
        public IActionResult Update(string id, UpdateCustomerModel body)
        {
            try
            {
                return Ok(_service.Update(new Customer
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
