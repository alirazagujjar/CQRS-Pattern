
using MediatR;
using Services;

namespace Assignment.Application.Command
{
    public class CustomerAddHandler: IRequestHandler<CustomerAddRequest, bool>
    {
        private readonly ICustomerRepository _repository;
        public CustomerAddHandler(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<bool> Handle(CustomerAddRequest request, CancellationToken cancellationToken)
        {
            
               
               var result= _repository.Add(request.Data);
                await _repository.SaveChangesAsync();
            return true;
            
            
        }
    }
 
}
