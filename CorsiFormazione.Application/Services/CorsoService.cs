using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Models.Entities;
using CorsiFormazione.Models.Repositories;

namespace CorsiFormazione.Application.Services
{
    public class CorsoService : ICorsoService
    {
        private readonly CorsoRepository _corsoRepo;

        public CorsoService(CorsoRepository corsoRepo)
        {
            _corsoRepo = corsoRepo;
        }

        public void AggiungiCorso(Corso corso, Docente docente)
        {
            _corsoRepo.AggiungiCorso(corso, docente);
            _corsoRepo.Save();
        }

        public void AggiungiLezione(Lezione lezione)
        {
            _corsoRepo.AggiungiLezione(lezione);
            _corsoRepo.Save();
        }

        public void EliminaCorso(string nomeCorso)
        {
            _corsoRepo.EliminaCorso(nomeCorso);
            _corsoRepo.Save();
        }
    }
}
