using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Abstractions.Services
{
    public interface IPresenzaService
    {
        void AggiungiPresenza(Presenza presenza, string luogo);

        void EliminaPresenza(string nome, string cognome, string corso);

        List<Presenza> RicercaPresenzeDaNomeCorso(int from, int num, string name, out int totalNum);
        List<Presenza> RicercaPresenzeDaDocente(string nome, string cognome);
        List<Presenza> RicercaPresenzeDaCognome(string cognome, string corso);
        List<Presenza> RicercaPresenzeDaCorsoEData(string corso, DateOnly data);


    }
}
