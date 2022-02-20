using MediatR;
using RYB.Cryptography;
using RYB.MediatR.Queries;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Commands;

public class GetUserTokenHandler : IRequestHandler<GetUserToken, string>
{
    private readonly IJwtUtils _jwtUtils;
    public GetUserTokenHandler(IJwtUtils jwtUtils)
    {
        _jwtUtils = jwtUtils;
    }

    public Task<string> Handle(GetUserToken request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_jwtUtils.GenerateJwtToken(new UserToken { Id = 123456, FirstName = "Test" }));
    }
}

