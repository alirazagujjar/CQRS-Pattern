using MediatR;
using Services;

namespace Assignment.Application.Command
{
    public class CustomerDeleteHandler
    {
    }
    public class FavouriteDeleteHandler : IRequestHandler<CustomerDeleteRequest, bool>
    {
        private readonly ICustomerRepository _repository;
        public FavouriteDeleteHandler(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<bool> Handle(CustomerDeleteRequest request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
