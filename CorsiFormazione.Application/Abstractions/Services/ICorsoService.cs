using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Abstractions.Services
{
    public interface ICorsoService
    {
        void AggiungiCorso(Corso corso, Docente docente, CalendarioLezioni lezioni);
        void EliminaCorso(string nomeCorso);
    }
}
