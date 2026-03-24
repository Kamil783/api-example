using Api_example.Data;
using Api_example.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_example.Repositories;

public class CustomerRepository(AppDbContext dbContext) : ICustomerRepository
{
    public async Task<List<Customer>> GetAllAsync() => await dbContext.Customers.AsNoTracking().ToListAsync();

    public async Task<Customer?> GetByIdAsync(int id) => await dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Customer> CreateAsync(Customer customer)
    {
        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        var exists = await dbContext.Customers.AnyAsync(x => x.Id == customer.Id);
        if (!exists)
        {
            return false;
        }

        dbContext.Customers.Update(customer);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await dbContext.Customers.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        dbContext.Customers.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
