using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Models.Entities;
using CorsiFormazione.Models.Repositories;

namespace CorsiFormazione.Application.Services
{
    public class PresenzaService : IPresenzaService
    {
        private readonly PresenzaRepository _presenzaRepo;

        public PresenzaService(PresenzaRepository presenzaRepo)
        {
            _presenzaRepo = presenzaRepo;
        }

        public void AggiungiPresenza(Presenza presenza)
        {
            _presenzaRepo.AggiungiPresenza(presenza, presenza.Corso.ToLower());
            _presenzaRepo.Save();
        }

        public void EliminaPresenza(string nome, string cognome, string corso, DateTime data)
        {

            _presenzaRepo.EliminaPresenza(nome, cognome, corso, data);
            _presenzaRepo.Save();
        }

        public List<Presenza> RicercaPresenzeDaNomeCorso(int from, int num, int numeroPaginaVisualizzare,string nomeCorso, out int totalNum)
        {
            var presenze = _presenzaRepo.RicercaPresenzeCorso(from, num, numeroPaginaVisualizzare, nomeCorso, out totalNum);
            _presenzaRepo.Save();
            return presenze;
        }
    }
}
