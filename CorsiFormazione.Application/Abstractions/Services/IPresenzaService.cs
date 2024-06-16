using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Abstractions.Services
{
    public interface IPresenzaService
    {
        void AggiungiPresenza(Presenza presenza);

        void EliminaPresenza(string nome, string cognome, string corso, DateTime data);

        List<Presenza> RicercaPresenzeDaNomeCorso(int from, int num, string name, out int totalNum);
    }
}
