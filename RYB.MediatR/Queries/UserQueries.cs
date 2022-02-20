using MediatR;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Queries
{
    public record GetUsers : IRequest<IEnumerable<UserProfile>>;
    public record GetUserByEmail (string userEmail) : IRequest<IEnumerable<UserProfile>>;
}
