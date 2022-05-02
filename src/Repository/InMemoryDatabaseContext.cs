using Domain.Models;

namespace Repository
{
    public class InMemoryDatabaseContext
    {
        public ISet<Customer> Customers { get; } = new HashSet<Customer>();
    }
}