using AutoMapper;
using E_Commerce_App.Core.Common.DTOs;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.Helpers.UIHelper;

namespace E_Commerce_App.WebUI.Controllers
{
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
            return View(categories);
        }
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (id == 0 && category == null)
                return View(new Category());
            else
                return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                    await _categoryService.AddAsync(category);
                else
                    _categoryService.Update(category);

                return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCategories", await _categoryService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helpers.UIHelper.RenderRazorViewToString(this, "AddOrEdit", category) });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            _categoryService.Remove(category);
            return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCategories", await _categoryService.GetAllAsync()) });
        }
    }
}
