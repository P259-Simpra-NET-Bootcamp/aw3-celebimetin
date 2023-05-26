using Data.Context;
using Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<Category> GetProductsWithCategory()
    {
        return context.Set<Category>().Include(x => x.Products);
    }
}