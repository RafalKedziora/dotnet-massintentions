using Application.Dto;
using Application.Interfaces;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into AccountController");
        }

        [SwaggerOperation(Summary = "Register new user")]
        [HttpPost("Register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [SwaggerOperation(Summary = "Authenticate the current user")]
        [HttpPost("Login")]
        public ActionResult LoginUser([FromBody] LoginUserDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            if(token is null)
            {
                throw new BadRequestException("Invalid Username or Password");
            }
            return Ok(token);
        }
    }
}
