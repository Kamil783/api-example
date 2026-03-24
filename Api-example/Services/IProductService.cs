using Api_example.Models;

namespace Api_example.Services;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<bool> UpdateAsync(int id, Product product);
    Task<bool> DeleteAsync(int id);
}
