using MediatR;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Queries
{
    public record GetUsers : IRequest<IEnumerable<UserProfile>>;
    public record GetUserByEmail (string userEmail) : IRequest<IEnumerable<UserProfile>>;
    public record GetUserByToken(string userId) : IRequest<UserProfile>;
    public record GetUserToken(string userId) : IRequest<string>;
}
