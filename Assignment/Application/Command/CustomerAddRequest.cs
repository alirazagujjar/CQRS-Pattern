using Domain;
using MediatR;

namespace Assignment.Application.Command
{
    public class CustomerAddRequest:IRequest<bool>
    {
        public Customer Data { get; set; }
    }
}
