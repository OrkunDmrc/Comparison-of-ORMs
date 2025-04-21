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
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
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
        public IActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
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
        public IActionResult Add(AddOrderModel body)
        {
            try
            {
                return Ok(_service.Add(new Order
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
        public IActionResult Update(int id, UpdateOrderModel body)
        {
            try
            {
                return Ok(_service.Update(new Order
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
