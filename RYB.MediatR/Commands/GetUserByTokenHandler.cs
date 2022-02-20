using MediatR;
using RYB.MediatR.Queries;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Commands;

public class GetUserByTokenHandler : IRequestHandler<GetUserByToken, UserProfile>
{
    public Task<UserProfile> Handle(GetUserByToken request, CancellationToken cancellationToken)
    {
        // TODO: return fake data untill data ready
        return Task.FromResult(new UserProfile
        {
            Email = request.userId,
            UserId = Guid.NewGuid(),
            Name = "Test Name"
        });
    }
}

