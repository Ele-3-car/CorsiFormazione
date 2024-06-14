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
            _context.Utenti.Add(utente);
        }

        public Utente PrendiUtente(string email)
        {
            Utente utente = _context.Utenti
                .FirstOrDefault(e => e.UtenteEmail == email);
            if (utente != null) { }
            {
                return utente;
            }
            throw new Exception("L'utente non è presente");
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
