using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Factories;
using CorsiFormazione.Application.Models.Requests;
using CorsiFormazione.Application.Models.Responses;
using CorsiFormazione.Application.Services;
using CorsiFormazione.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorsiFormazione.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PresenzaController : ControllerBase
    {
        private readonly PresenzaService _presenzaService;

        public PresenzaController(IPresenzaService presenzaService)
        {
            _presenzaService = (PresenzaService)presenzaService;
        }

        [HttpPost]
        [Route("aggiungiPresenza")]
        public IActionResult AggiungiPresenza(AggiungiPresenzaRequest request)
        {
            var presenza = request.ToEntity();
            _presenzaService.AggiungiPresenza(presenza);
            return Ok(ResponseFactory.WithSuccess($"Presenza di {request.NomeAlunno} {request.CognomeAlunno} al corso {request.Corso} aggiunta con successo"));
        }

        
        [HttpDelete]
        [Route("rimuoviPresenza")]
        public IActionResult EliminaPresenza(EliminaPresenzaRequest request)
        {
            _presenzaService.EliminaPresenza(request.NomeAlunno, request.CognomeAlunno, request.Corso, request.Data);
            return Ok(ResponseFactory.WithSuccess($"Presenza di {request.NomeAlunno} {request.CognomeAlunno} al corso {request.Corso} eliminata con successo"));
        }

        [HttpPost]
        [Route("presenzeCorsoDaNomeCorso")]
        public IActionResult RicercaPresenzeCorsoDaNomeCorso(RicercaPresenzaByNomeCorsoRequest request)
        {
            int totalNum = 0;
            var presenze = _presenzaService.RicercaPresenzeDaNomeCorso((request.NumeroPaginaVisualizzare-1) * request.PageSize, request.PageSize, request.NomeCorso, out totalNum);

            var response = new RicercaPresenzeResponse();
            var pageFounded = (totalNum / (decimal) request.PageSize);
            response.PaginaVisualizzata = request.NumeroPaginaVisualizzare;
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Presenze = presenze.Select(s =>
                new Application.Models.Dtos.PresenzaDto(s)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
