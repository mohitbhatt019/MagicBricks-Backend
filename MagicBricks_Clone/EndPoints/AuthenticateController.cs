using MagicBricks.Applications.Interfaces.IRepository;
using MagicBricks.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MagicBricks_Clone.EndPoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationRepository _authentication;

        private readonly ILogger<AuthenticateController> _logger;


        public AuthenticateController(IAuthenticationRepository authentication, ILogger<AuthenticateController> logger)
        {
            _authentication = authentication;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserVm vm)

        {
            if (vm == null) throw new ArgumentNullException(nameof(vm));
            var registerUser = await _authentication.RegisterUser(vm);
            if (!registerUser) return BadRequest();
            return Ok(registerUser);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(SignUserVm vm)

        {
            _logger.LogInformation("Seri Log is Working");
            if (vm == null) throw new ArgumentNullException(nameof(vm));
            var registerUser = await _authentication.Login(vm);
            if (registerUser == null) return BadRequest();
            return Ok(registerUser);

        }

    }
}
