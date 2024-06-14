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
        public readonly ITokenService _tokenService;

        public TokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("createToken")]
        public IActionResult CreateToken(CreateTokenRequest request)
        {
            //validazione richiesta (validator)
            string token = _tokenService.CreateToken(request);
            return Ok(ResponseFactory.WithSuccess(new CreateTokenResponse(token)));
        }

    }
}
