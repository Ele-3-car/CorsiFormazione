using CorsiFormazione.Models.Context;
using CorsiFormazione.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Repositories
{
    public class UtenteRepository
    {
        protected MyDbContext _context;

        public UtenteRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AggiungiUtente(Utente utente)
        {
            var verificaUtente = _context.Utenti
                .Where(e => e.UtenteEmail == utente.UtenteEmail)
                .FirstOrDefault();
            if (verificaUtente == null)
            {
                _context.Utenti.Add(utente);
            }
            throw new Exception("L'utente non è presente");
        }

        public Utente PrendiUtente(string email, string password)
        {
            var utente = _context.Utenti
                .Where(e => e.UtenteEmail == email)
                .FirstOrDefault();
            if (utente == null)
            {
                throw new Exception("L'utente non è presente");
            }
            if(utente.Password != password)
            {
                throw new Exception("Password errata");
            }
            return utente;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
