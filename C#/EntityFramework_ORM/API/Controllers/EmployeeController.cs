using API.Models.EmployeeModels;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(new GetEmployeeModel()
                {
                    EmployeeID = entity.EmployeeID,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Title = entity.Title,
                    TitleOfCourtesy = entity.TitleOfCourtesy,
                    BirthDate = entity.BirthDate,
                    HireDate = entity.HireDate,
                    Address = entity.Address,
                    City = entity.City,
                    Region = entity.Region,
                    PostalCode = entity.PostalCode,
                    Country = entity.Country,
                    HomePhone = entity.HomePhone,
                    Extension = entity.Extension,
                    Photo = entity.Photo,
                    Notes = entity.Notes,
                    ReportsTo = entity.ReportsTo,
                    PhotoPath = entity.PhotoPath,
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
                return Ok(entities.Select(entity => new GetEmployeeModel()
                {
                    EmployeeID = entity.EmployeeID,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Title = entity.Title,
                    TitleOfCourtesy = entity.TitleOfCourtesy,
                    BirthDate = entity.BirthDate,
                    HireDate = entity.HireDate,
                    Address = entity.Address,
                    City = entity.City,
                    Region = entity.Region,
                    PostalCode = entity.PostalCode,
                    Country = entity.Country,
                    HomePhone = entity.HomePhone,
                    Extension = entity.Extension,
                    Photo = entity.Photo,
                    Notes = entity.Notes,
                    ReportsTo = entity.ReportsTo,
                    PhotoPath = entity.PhotoPath,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Add(AddEmployeeModel body)
        {
            try
            {
                return Ok(_service.Add(new Employee
                {
                    LastName = body.LastName,
                    FirstName = body.FirstName,
                    Title = body.Title,
                    TitleOfCourtesy= body.TitleOfCourtesy, 
                    BirthDate = body.BirthDate,
                    HireDate = body.HireDate,
                    Address = body.Address,
                    City = body.City,
                    Region = body.Region,
                    PostalCode = body.PostalCode,
                    Country = body.Country,
                    HomePhone = body.HomePhone,
                    Extension = body.Extension,
                    Photo = body.Photo,
                    Notes = body.Notes,
                    ReportsTo = body.ReportsTo,
                    PhotoPath = body.PhotoPath,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateEmployeeModel body)
        {
            try
            {
                return Ok(_service.Update(new Employee
                {
                    EmployeeID = id,
                    LastName = body.LastName,
                    FirstName = body.FirstName,
                    Title = body.Title,
                    TitleOfCourtesy = body.TitleOfCourtesy,
                    BirthDate = body.BirthDate,
                    HireDate = body.HireDate,
                    Address = body.Address,
                    City = body.City,
                    Region = body.Region,
                    PostalCode = body.PostalCode,
                    Country = body.Country,
                    HomePhone = body.HomePhone,
                    Extension = body.Extension,
                    Photo = body.Photo,
                    Notes = body.Notes,
                    ReportsTo = body.ReportsTo,
                    PhotoPath = body.PhotoPath,
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
