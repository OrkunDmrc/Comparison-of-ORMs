using API.Models.ProductModels;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(new GetProductModel()
                {
                    ProductID = entity.ProductID,
                    ProductName = entity.ProductName,
                    SupplierID = entity.SupplierID,
                    CategoryID = entity.CategoryID,
                    QuantityPerUnit = entity.QuantityPerUnit,
                    UnitPrice = entity.UnitPrice,
                    UnitsInStock = entity.UnitsInStock,
                    UnitsOnOrder = entity.UnitsOnOrder,
                    ReorderLevel = entity.ReorderLevel,
                    Discontinued = entity.Discontinued,
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
                return Ok(entities.Select(entity => new GetProductModel()
                {
                    ProductID = entity.ProductID,
                    ProductName = entity.ProductName,
                    SupplierID = entity.SupplierID,
                    CategoryID = entity.CategoryID,
                    QuantityPerUnit = entity.QuantityPerUnit,
                    UnitPrice = entity.UnitPrice,
                    UnitsInStock = entity.UnitsInStock,
                    UnitsOnOrder = entity.UnitsOnOrder,
                    ReorderLevel = entity.ReorderLevel,
                    Discontinued = entity.Discontinued,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Add(AddProductModel body)
        {
            try
            {
                return Ok(_service.Add(new Product
                {
                    ProductName = body.ProductName,
                    SupplierID = body.SupplierID,
                    CategoryID = body.CategoryID,
                    QuantityPerUnit = body.QuantityPerUnit,
                    UnitPrice = body.UnitPrice,
                    UnitsInStock = body.UnitsInStock,
                    UnitsOnOrder = body.UnitsOnOrder,
                    ReorderLevel = body.ReorderLevel,
                    Discontinued = body.Discontinued,
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductModel body)
        {
            try
            {
                return Ok(_service.Update(new Product
                {
                    ProductID = id,
                    ProductName = body.ProductName,
                    SupplierID = body.SupplierID,
                    CategoryID = body.CategoryID,
                    QuantityPerUnit = body.QuantityPerUnit,
                    UnitPrice = body.UnitPrice,
                    UnitsInStock = body.UnitsInStock,
                    UnitsOnOrder = body.UnitsOnOrder,
                    ReorderLevel = body.ReorderLevel,
                    Discontinued = body.Discontinued,
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
