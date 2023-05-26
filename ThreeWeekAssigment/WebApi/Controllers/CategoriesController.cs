using AutoMapper;
using Core.UnitOfWork;
using Data.Domains;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Schemas;

namespace WebApi.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository)
            : base(unitOfWork, mapper)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public List<CategoryResponse> GetAll()
        {
            var categories = categoryRepository.GetProductsWithCategory();
            return mapper.Map<List<CategoryResponse>>(categories);
        }

        [HttpGet("{id}")]
        public CategoryResponse GetById(int id)
        {
            var category = categoryRepository.GetById(id);
            return mapper.Map<CategoryResponse>(category);
        }

        [HttpPost]
        public CategoryResponse Add(CategoryRequest request)
        {
            var category = mapper.Map<Category>(request);
            categoryRepository.Add(category);
            category.Products.ForEach(p =>
            {
                p.CategoryId = category.Id;
            });
            unitOfWork.Commit();
            return mapper.Map<CategoryResponse>(category);
        }

        [HttpPut("{id}")]
        public CategoryResponse Update(CategoryResponse request, int id)
        {
            var category = mapper.Map<Category>(request);
            if (category.Id.Equals(id))
                categoryRepository.Update(category);
            unitOfWork.Commit();
            return mapper.Map<CategoryResponse>(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category != null && category.Id.Equals(id))
                categoryRepository.Delete(id);
            unitOfWork.Commit();
        }
    }
}