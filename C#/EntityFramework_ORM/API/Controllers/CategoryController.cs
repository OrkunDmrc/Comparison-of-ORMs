﻿using API.Models.CategoyModels;
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.GetAllAsync();
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
        public async Task<IActionResult> Add(AddCategoryModel body)
        {
            try
            {
                return Ok(await _service.AddAsync(new Category
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
        public async Task<IActionResult> Update(int id, UpdateCategoryModel body)
        {
            try
            {
                return Ok(await _service.UpdateAsync(new Category
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
