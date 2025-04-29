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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.GetAllAsync();
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
        public async Task<IActionResult> Add(AddEmployeeModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Employee
                {
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeModel body)
        {
            try
            {
                await _service.UpdateAsync(new Employee
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
