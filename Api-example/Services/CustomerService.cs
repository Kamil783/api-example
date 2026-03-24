using Api_example.Models;
using Api_example.Repositories;

namespace Api_example.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task<List<Customer>> GetAllAsync() => await customerRepository.GetAllAsync();

    public async Task<Customer?> GetByIdAsync(int id) => await customerRepository.GetByIdAsync(id);

    public async Task<Customer> CreateAsync(Customer customer)
    {
        customer.Id = 0;
        return await customerRepository.CreateAsync(customer);
    }

    public async Task<bool> UpdateAsync(int id, Customer customer)
    {
        customer.Id = id;
        return await customerRepository.UpdateAsync(customer);
    }

    public async Task<bool> DeleteAsync(int id) => await customerRepository.DeleteAsync(id);
}
