using Core.Notifications;
using Domain.Contracts;
using Domain.Models;
using MediatR;

namespace Application.Features.CustomerContext
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomer, Guid>
    {
        private readonly NotificationContext _notificationContext;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(
            NotificationContext notificationContext,
            ICustomerRepository customerRepository)
        {
            _notificationContext = notificationContext;
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Email);

            if (customer.Invalid)
            {
                _notificationContext.AddNotifications(customer.ValidationResult);
                return Guid.Empty;
            }

            await _customerRepository.Save(customer);

            return customer.Id;
        }
    }
}