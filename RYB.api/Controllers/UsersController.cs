﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RYB.Model.ViewModel;

namespace RYB.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediatR, ILogger<UsersController> logger)
        {
            _mediatR = mediatR;
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation("Test message");
            return Ok(await _mediatR.Send(new MediatR.Queries.GetUsers()));
        }

        [HttpGet]
        [Route("{userEmail}")]
        public async Task<IActionResult> GetUser(string userEmail)
        {
            IEnumerable<UserProfile> users = await _mediatR.Send(new MediatR.Queries.GetUserByEmail(userEmail), default(CancellationToken));
            if (users.Any())
                return Ok(users);
            else
                return NoContent();
        }
    }
}
