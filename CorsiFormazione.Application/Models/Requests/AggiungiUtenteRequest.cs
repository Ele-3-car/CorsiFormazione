using CorsiFormazione.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Models.Requests
{
    public class AggiungiUtenteRequest
    {
        public string UtenteEmail { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Password { get; set; }

        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.UtenteEmail = UtenteEmail;
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Password = Password;

            return utente;
        }
    }
}
