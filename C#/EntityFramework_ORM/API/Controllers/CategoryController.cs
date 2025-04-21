using API.Models.CategoyModels;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;
        public CategoryController(CategoryService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(new GetCategoryModel()
                {
                    CategoryID = entity.CategoryID,
                    CategoryName = entity.CategoryName,
                    Description = entity.Description,
                    Picture = entity.Picture
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
                return Ok(entities.Select(entity => new GetCategoryModel()
                {
                    CategoryID = entity.CategoryID,
                    CategoryName = entity.CategoryName,
                    Description = entity.Description,
                    Picture = entity.Picture
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Add(AddCategoryModel body)
        {
            try
            {
                return Ok(_service.Add(new Category
                {
                    CategoryName = body.CategoryName,
                    Description = body.Description,
                    Picture = body.Picture
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryModel body)
        {
            try
            {
                return Ok(_service.Update(new Category
                {
                    CategoryID = id,
                    CategoryName = body.CategoryName,
                    Description = body.Description,
                    Picture = body.Picture
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
