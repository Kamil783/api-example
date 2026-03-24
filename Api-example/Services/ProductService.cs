using Api_example.Models;
using Api_example.Repositories;

namespace Api_example.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<List<Product>> GetAllAsync() => await productRepository.GetAllAsync();

    public async Task<Product?> GetByIdAsync(int id) => await productRepository.GetByIdAsync(id);

    public async Task<Product> CreateAsync(Product product)
    {
        product.Id = 0;
        return await productRepository.CreateAsync(product);
    }

    public async Task<bool> UpdateAsync(int id, Product product)
    {
        product.Id = id;
        return await productRepository.UpdateAsync(product);
    }

    public async Task<bool> DeleteAsync(int id) => await productRepository.DeleteAsync(id);
}
