using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Abstractions.Services
{
    public interface ICorsoService
    {
        void AggiungiCorso(Corso corso, Docente docente);
        void EliminaCorso(string nomeCorso);
        void AggiungiLezione(Lezione lezione);
    }
}
