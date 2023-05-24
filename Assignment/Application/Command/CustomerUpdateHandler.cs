using MediatR;
using Services;

namespace Assignment.Application.Command
{
    public class CustomerUpdateHandler : IRequestHandler<CustomerUpdateRequest, bool>
    {
        private readonly ICustomerRepository _repository;
        public CustomerUpdateHandler(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<bool> Handle(CustomerUpdateRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Data.Id);
            if (user == null)
            {
                request.Data.Id = user.Id;
                _repository.Update(request.Data);
                await _repository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
