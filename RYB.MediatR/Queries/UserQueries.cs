using MediatR;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Queries
{
    public record GetUsers : IRequest<IEnumerable<User>>;
    public record GetUserByEmail (string userEmail) : IRequest<IEnumerable<User>>;
}
