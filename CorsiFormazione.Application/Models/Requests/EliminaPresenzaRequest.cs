using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Requests
{
    public class EliminaPresenzaRequest
    {
        public string NomeAlunno { get; set; }
        public string CognomeAlunno { get; set; }
        public string Corso {  get; set; }
        public DateTime Data {  get; set; }
    }
}
