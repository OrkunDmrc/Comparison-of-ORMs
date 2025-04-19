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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.GetAllAsync();
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
        public async Task<IActionResult> Add(AddProductModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Product
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
        public async Task<IActionResult> Update(int id, UpdateProductModel body)
        {
            try
            {
                return Ok(await _service.UpdateAsync(new Product
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
