using Api_example.Data;
using Api_example.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_example.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync() => await dbContext.Products.AsNoTracking().ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) => await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Product> CreateAsync(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        var exists = await dbContext.Products.AnyAsync(x => x.Id == product.Id);
        if (!exists)
        {
            return false;
        }

        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await dbContext.Products.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        dbContext.Products.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
