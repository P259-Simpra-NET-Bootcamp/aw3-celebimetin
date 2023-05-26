using AutoMapper;
using Core.UnitOfWork;
using Data.Domains;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Schemas;

namespace WebApi.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
            : base(unitOfWork, mapper)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public List<ProductResponse> GetAll()
        {
            var products = productRepository.GetAll().ToList();
            return mapper.Map<List<ProductResponse>>(products);
        }

        [HttpGet("{id}")]
        public ProductResponse GetById(int id)
        {
            var product = productRepository.GetById(id);
            return mapper.Map<ProductResponse>(product);
        }

        [HttpPost]
        public ProductResponse Add(ProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            productRepository.Add(product);
            unitOfWork.Commit();
            return mapper.Map<ProductResponse>(product);
        }

        [HttpPut("{id}")]
        public ProductResponse Update(ProductRequest request, int id)
        {
            var product = mapper.Map<Product>(request);
            if (product != null && product.Id.Equals(id))
                productRepository.Update(product);
            unitOfWork.Commit();
            return mapper.Map<ProductResponse>(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = productRepository.GetById(id);
            if (product != null && product.Id.Equals(id))
                productRepository.Delete(id);
            unitOfWork.Commit();
        }
    }
}