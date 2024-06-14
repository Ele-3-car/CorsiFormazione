using CorsiFormazione.Application.Models.Dtos;

namespace CorsiFormazione.Application.Models.Responses
{
    public class RicercaPresenzeResponse
    {
        public List<PresenzaDto> Presenze { get; set; } = new List<PresenzaDto>();
        public int PaginaVisualizzata { get; set; }
        public int NumeroPagine { get; set; }
    }
}
