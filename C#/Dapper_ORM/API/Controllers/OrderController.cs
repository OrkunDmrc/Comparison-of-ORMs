using API.Models.OrderModels;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;
        public OrderController(OrderService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                return Ok(new GetOrderModel()
                {
                    OrderID = entity.OrderID,
                    CustomerID = entity.CustomerID,
                    EmployeeID = entity.EmployeeID,
                    OrderDate = entity.OrderDate,
                    RequiredDate = entity.RequiredDate,
                    ShippedDate = entity.ShippedDate,
                    ShipVia = entity.ShipVia,
                    Freight = entity.Freight,
                    ShipName = entity.ShipName,
                    ShipAddress = entity.ShipAddress,
                    ShipCity = entity.ShipCity,
                    ShipRegion = entity.ShipRegion,
                    ShipPostalCode = entity.ShipPostalCode,
                    ShipCountry = entity.ShipCountry
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
                return Ok(entities.Select(entity => new GetOrderModel()
                {
                    OrderID = entity.OrderID,
                    CustomerID = entity.CustomerID,
                    EmployeeID = entity.EmployeeID,
                    OrderDate = entity.OrderDate,
                    RequiredDate = entity.RequiredDate,
                    ShippedDate = entity.ShippedDate,
                    ShipVia = entity.ShipVia,
                    Freight = entity.Freight,
                    ShipName = entity.ShipName,
                    ShipAddress = entity.ShipAddress,
                    ShipCity = entity.ShipCity,
                    ShipRegion = entity.ShipRegion,
                    ShipPostalCode = entity.ShipPostalCode,
                    ShipCountry = entity.ShipCountry
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Order
                {
                    CustomerID = body.CustomerID,
                    EmployeeID = body.EmployeeID,
                    OrderDate = body.OrderDate,
                    RequiredDate = body.RequiredDate,
                    ShippedDate = body.ShippedDate,
                    ShipVia = body.ShipVia,
                    Freight = body.Freight,
                    ShipName = body.ShipName,
                    ShipAddress = body.ShipAddress,
                    ShipCity = body.ShipCity,
                    ShipRegion = body.ShipRegion,
                    ShipPostalCode = body.ShipPostalCode,
                    ShipCountry = body.ShipCountry
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderModel body)
        {
            try
            {
                await _service.UpdateAsync(new Order
                {
                    OrderID = id,
                    CustomerID = body.CustomerID,
                    EmployeeID = body.EmployeeID,
                    OrderDate = body.OrderDate,
                    RequiredDate = body.RequiredDate,
                    ShippedDate = body.ShippedDate,
                    ShipVia = body.ShipVia,
                    Freight = body.Freight,
                    ShipName = body.ShipName,
                    ShipAddress = body.ShipAddress,
                    ShipCity = body.ShipCity,
                    ShipRegion = body.ShipRegion,
                    ShipPostalCode = body.ShipPostalCode,
                    ShipCountry = body.ShipCountry
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
