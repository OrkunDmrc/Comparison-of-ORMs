using API.Models.EmployeeModels;
using API.Models.Order_DetailModels;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class Order_DetailController : ControllerBase
    {
        private readonly Order_DetailService _service;
        public Order_DetailController(Order_DetailService service)
        {
            _service = service;
        }
        [HttpGet("{orderId}&{productId}")]
        public IActionResult Get(int orderId, int productId)
        {
            try
            {
                var entity = _service.GetByIdAsync(orderId, productId);
                return Ok(new GetOrder_DetailModel()
                {
                    OrderID = entity.OrderID,
                    ProductID = entity.ProductID,
                    UnitPrice = entity.UnitPrice,
                    Quantity = entity.Quantity,
                    Discount = entity.Discount,
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
                var entities = _service.GetAllAsync();
                return Ok(entities.Select(entity => new GetOrder_DetailModel()
                {
                    OrderID = entity.OrderID,
                    ProductID = entity.ProductID,
                    UnitPrice = entity.UnitPrice,
                    Quantity = entity.Quantity,
                    Discount = entity.Discount,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Add(AddOrder_DetailModel body)
        {
            try
            {
                return Ok(_service.Add(new Order_Detail
                {
                    OrderID = body.OrderID,
                    ProductID = body.ProductID,
                    UnitPrice = body.UnitPrice,
                    Quantity = body.Quantity,
                    Discount = body.Discount
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{orderId}&{productId}")]
        public IActionResult Delete(int orderId, int productId)
        {
            try
            {
                return Ok(_service.Delete(orderId, productId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
