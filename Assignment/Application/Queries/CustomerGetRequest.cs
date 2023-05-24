using Domain;
using MediatR;

namespace Assignment.Application.Queries
{
    public class CustomerGetRequest:IRequest<List<Customer>>
    {
    }
}
