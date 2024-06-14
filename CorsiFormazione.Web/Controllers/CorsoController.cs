using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Factories;
using CorsiFormazione.Application.Models.Requests;
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
            var corso = request.ToEntity();
            var docente = request.ToEntityDocente();
            var calendario = request.ToEntityCalendario();
            _corsoService.AggiungiCorso(corso, docente, calendario);
            return Ok(ResponseFactory.WithSuccess(corso));
        }

        [HttpDelete]
        [Route("eliminaCorso")]
        public IActionResult EliminaCorso(EliminaCorsoRequest request)
        {
            _corsoService.EliminaCorso(request.Nome);
            return Ok(ResponseFactory.WithSuccess("Corso eliminato con successo"));
        }

        /*
        //Deve essere paginato
        [HttpGet]
        [Route("ricercaPresenzePerCorso")]
        public IActionResult RicercaPresenze(RicercaPresenzeRequest request)
        {
            return Ok();
        }*/
    }
}
