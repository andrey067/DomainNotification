using Domain.Models;
using MediatR;

namespace Application.Features.CustomerContext
{
    public class FindCustomer : IRequest<Customer>
    {
        public Guid Id { get; }

        public FindCustomer(Guid id)
        {
            Id = id;
        }
    }
}