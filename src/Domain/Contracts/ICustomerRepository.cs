using Domain.Models;

namespace Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task Save(Customer customer);
        Task<Customer> Find(Guid id);
    }
}