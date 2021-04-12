using E_Commerce_App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            /*En çok ürünü olan top 8 kategoriyi getiren metodu yazalım bunun yerine sonrasında*/
            return View(_categoryService.GetAllAsync().Result);
        }
    }
}
