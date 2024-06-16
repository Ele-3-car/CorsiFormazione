using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Factories;
using CorsiFormazione.Application.Models.Requests;
using CorsiFormazione.Application.Models.Responses;
using CorsiFormazione.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorsiFormazione.Web.Controllers
{
    [ApiController]
    [Route("api/Authentication/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = (TokenService) tokenService;
        }

        [HttpPost]
        [Route("createToken")]
        public IActionResult CreateToken(CreateTokenRequest request)
        {
            string token = _tokenService.CreateToken(request);
            return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
        }

    }
}
