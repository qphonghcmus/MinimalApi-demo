using CleanMinimalApi.Models;

namespace CleanMinimalApi.Repositories;

public interface ICustomerRepository
{
    void Create(Customer? customer);
    void Delete(Guid id);
    List<Customer> GetAll();
    Customer? GetById(Guid id);
    void Update(Customer customer);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly Dictionary<Guid, Customer> _customers = new();

    public void Create(Customer? customer)
    {
        if (customer is null) return;
        _customers[customer.Id] = customer;
    }

    public Customer? GetById(Guid id) => _customers.GetValueOrDefault(id);

    public List<Customer> GetAll() => _customers.Values.ToList();

    public void Update(Customer customer)
    {
        var existingCustomer = GetById(customer.Id);
        if (existingCustomer is null) return;
        _customers[customer.Id] = customer;
    }

    public void Delete(Guid id)
    {
        _customers.Remove(id);
    }
}
