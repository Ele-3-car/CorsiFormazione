using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Models.Entities;
using CorsiFormazione.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepo;

        public UtenteService(UtenteRepository utenteRepo)
        {
            _utenteRepo = utenteRepo;
        }

        public void AggiungiUtente(Utente utente)
        {
            _utenteRepo.AggiungiUtente(utente);
            _utenteRepo.Save();
        }

        public Utente PrendiUtente(string email)
        {
            return _utenteRepo.PrendiUtente(email);
        }
    }
}
