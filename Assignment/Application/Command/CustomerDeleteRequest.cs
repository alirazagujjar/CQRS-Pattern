using MediatR;

namespace Assignment.Application.Command
{
    public class CustomerDeleteRequest:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
