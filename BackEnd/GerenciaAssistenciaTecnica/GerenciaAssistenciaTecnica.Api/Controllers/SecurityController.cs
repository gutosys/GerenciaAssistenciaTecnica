using GerenciaAssistenciaTecnica.Api.Models;
using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : BaseApiController
    {
        private JwtSettings _settings;
        private IUserRepository _userRepository;
        public SecurityController(JwtSettings settings, IUserRepository userRepository)
        {
            _settings = settings;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]AppUser user)
        {
            IActionResult ret = null;
            AppUserAuth auth = new AppUserAuth();
            SecurityManager mgr = new SecurityManager(_settings, _userRepository);

            auth = mgr.ValidateUser(user);
            if (auth.IsAuthenticated)
            {
                ret = StatusCode(StatusCodes.Status200OK, auth);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound,
                                 "Invalid User Name/Password.");
            }

            return ret;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser([FromBody] AppUser user)
        {
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _userRepository.UserNameExistsAsync(user.UserName))
            {
                return Conflict("A user with this username already exists.");
            }

            user.UserId = Guid.NewGuid();
            var createdUser = await _userRepository.AddAsync(user);

            return StatusCode(StatusCodes.Status201Created, new
            {
                createdUser.UserId,
                createdUser.UserName
            });
        }
    }
}