using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Factories;
using CorsiFormazione.Application.Models.Requests;
using CorsiFormazione.Application.Models.Responses;
using CorsiFormazione.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorsiFormazione.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CorsoController : ControllerBase
    {
        private readonly CorsoService _corsoService;

        public CorsoController(ICorsoService corsoService)
        {
            _corsoService = (CorsoService) corsoService;
        }

        [HttpPost]
        [Route("creaCorso")]
        public IActionResult CreaCorso(CreaCorsoRequest request)
        {
            var corso = request.ToEntityCorso();
            var docente = request.ToEntityDocente();
            _corsoService.AggiungiCorso(corso, docente);
            var response = new CreaCorsoResponse(corso);
            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpDelete]
        [Route("eliminaCorso")]
        public IActionResult EliminaCorso(EliminaCorsoRequest request)
        {
            _corsoService.EliminaCorso(request.Nome);
            return Ok(ResponseFactory.WithSuccess("Corso, docente, calendario e presenze eliminati con successo"));
        }


        [HttpPost]
        [Route("aggiungiLezione")]
        public IActionResult AggiungiLezione(AggiungiLezioneRequest request)
        {
            var lezione = request.ToEntity();
            _corsoService.AggiungiLezione(lezione);
            return Ok(ResponseFactory.WithSuccess("La lezione è stata aggiunta con successo"));
        }
    }
}
