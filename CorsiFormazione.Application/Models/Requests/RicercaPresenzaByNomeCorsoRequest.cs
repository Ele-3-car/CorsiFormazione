namespace CorsiFormazione.Application.Models.Requests
{
    public class RicercaPresenzaByNomeCorsoRequest
    {
        public int PageSize { get; set; }
        public int NumeroPaginaVisualizzare { get; set; } 
        public string NomeCorso { get; set; }
    }
}
