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

        public void AggiungiPresenza(Presenza presenza, string corso)
        {
            _presenzaRepo.AggiungiPresenza(presenza, corso);
            _presenzaRepo.Save();
        }

        public void EliminaPresenza(string nome, string cognome, string corso)
        {

            _presenzaRepo.EliminaPresenza(nome, cognome, corso);
            _presenzaRepo.Save();
        }

        public List<Presenza> RicercaPresenzeDaNomeCorso(int from, int num, string nomeCorso, out int totalNum)
        {
            var presenze = _presenzaRepo.RicercaPresenzeCorso(from, num, nomeCorso, out totalNum);
            _presenzaRepo.Save();
            return presenze;
        }

        public List<Presenza> RicercaPresenzeDaDocente(string nome, string cognome)
        {
            var presenze = _presenzaRepo.RicercaPresenzeDocente(nome, cognome);
            _presenzaRepo.Save();
            return presenze;
        }

        public List<Presenza> RicercaPresenzeDaCorsoEData(string corso, DateOnly data)
        {
            var presenze = _presenzaRepo.RicercaPresenzeCorsoEData(corso, data);
            _presenzaRepo.Save();
            return presenze;
        }
        
        public List<Presenza> RicercaPresenzeDaCognome(string cognome, string corso)
        {
            var presenze = _presenzaRepo.RicercaPresenzeCorsoCognomeECorso(cognome, corso);
            _presenzaRepo.Save();
            return presenze;
        }
    }
}
