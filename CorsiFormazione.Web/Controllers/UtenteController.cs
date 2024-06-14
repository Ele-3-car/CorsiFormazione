using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Models.Requests;
using CorsiFormazione.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CorsiFormazione.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly UtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = (UtenteService) utenteService;
        }

        [HttpPost]
        [Route("aggiungiUtente")]
        public IActionResult AggiungiUtente(AggiungiUtenteRequest request)
        {
            var utente = request.ToEntity();
            _utenteService.AggiungiUtente(utente);
            return Ok(request);
        }
    }
}
