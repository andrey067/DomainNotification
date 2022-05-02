using Domain.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Features.CustomerContext
{
    public class FindCustomerHandler : IRequestHandler<FindCustomer, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public FindCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(FindCustomer request, CancellationToken cancellationToken)
        {
            return await _customerRepository.Find(request.Id);
        }
    }
}