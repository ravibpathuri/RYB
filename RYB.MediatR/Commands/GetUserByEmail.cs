using MediatR;
using RYB.Business;
using RYB.MediatR.Queries;
using RYB.Model.ViewModel;

namespace RYB.MediatR.Commands
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmail, IEnumerable<User>>
    {
        private readonly IUserRepo _userRepo;

        public GetUserByEmailHandler(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> Handle(GetUserByEmail request, CancellationToken cancellationToken)
        {
            return await _userRepo.GetUserByEmail(request.userEmail);
        }
    }
}
