using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace E_Commerce_App.Business.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository) { }
        public Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return _unitOfWork.CategoryRepository.GetWithProductsByIdAsync(categoryId);
        }
    }
}
