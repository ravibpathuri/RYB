using MediatR;
using Microsoft.AspNetCore.Mvc;
using RYB.Model.ViewModel;

namespace RYB.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public UsersController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _mediatR.Send(new MediatR.Queries.GetUsers(), default(CancellationToken)));
        }

        [HttpGet]
        [Route("{userEmail}")]
        public async Task<IActionResult> GetUser(string userEmail)
        {
            IEnumerable<User> users = await _mediatR.Send(new MediatR.Queries.GetUserByEmail(userEmail), default(CancellationToken));
            if (users.Any())
                return Ok(users);
            else
                return NoContent();
        }
    }
}
