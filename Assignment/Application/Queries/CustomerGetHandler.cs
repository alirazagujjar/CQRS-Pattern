using Domain;
using MediatR;
using Services;

namespace Assignment.Application.Queries
{
    public class CustomerGetHandler : IRequestHandler<CustomerGetRequest, List<Customer>>
    {
        private readonly ICustomerRepository _repository;
        public CustomerGetHandler(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            
        }
        public async Task<List<Customer>> Handle(CustomerGetRequest request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAsync();
            return customers;
        }
    }
}
