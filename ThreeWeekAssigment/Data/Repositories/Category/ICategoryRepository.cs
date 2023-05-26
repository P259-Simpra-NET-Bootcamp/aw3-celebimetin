using Core.BaseRepository;
using Data.Domains;

namespace Data.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    IQueryable<Category> GetProductsWithCategory();
}