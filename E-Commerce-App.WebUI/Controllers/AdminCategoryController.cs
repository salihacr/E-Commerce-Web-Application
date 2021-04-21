using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.Helpers.UIHelper;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public AdminCategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (id == 0 && category == null)
                return View(new CategoryDto());
            else
                return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                if (categoryDto.Id == 0)
                {
                    categoryDto.CreationDate = DateTime.Now;
                    await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
                }
                else
                {
                    categoryDto.DateOfUpdate = DateTime.Now;
                    _categoryService.Update(_mapper.Map<Category>(categoryDto));
                }
                var categories = _mapper.Map<IEnumerable<CategoryDto>>(await _categoryService.GetAllAsync());
                return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCategories", categories) });
            }
            return Json(new { isValid = false, html = Helpers.UIHelper.RenderRazorViewToString(this, "AddOrEdit", categoryDto) });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
                _categoryService.Remove(category);

            var categories = _mapper.Map<IEnumerable<CategoryDto>>(await _categoryService.GetAllAsync());
            return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCategories", categories) });
        }
    }
}
