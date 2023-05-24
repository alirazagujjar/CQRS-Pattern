using Domain;
using MediatR;

namespace Assignment.Application.Command
{
    public class CustomerUpdateRequest : IRequest<bool>
    {
        public Customer Data { get; set; }
    }
}
