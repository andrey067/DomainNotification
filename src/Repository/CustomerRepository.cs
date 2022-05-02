using Domain.Contracts;
using Domain.Models;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InMemoryDatabaseContext _databaseContext;

        public CustomerRepository(InMemoryDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task Save(Customer customer)
        {
            _databaseContext.Customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task<Customer> Find(Guid id)
        {
            var customer = _databaseContext.Customers.FirstOrDefault(a => a.Id.Equals(id));
            return Task.FromResult(customer);
        }
    }
}