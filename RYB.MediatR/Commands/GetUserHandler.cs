using MediatR;
using RYB.Business;
using RYB.MediatR.Queries;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Commands
{
    public class GetUserHandler : IRequestHandler<GetUsers, IEnumerable<UserProfile>>
    {
        private readonly IUserRepo _userRepo;

        public GetUserHandler(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            return await _userRepo.GetUsers();
        }
    }
}
