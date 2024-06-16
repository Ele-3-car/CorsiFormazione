using CorsiFormazione.Models.Context;
using CorsiFormazione.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Repositories
{
    public class CorsoRepository 
    {
        private readonly MyDbContext _context;

        public CorsoRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AggiungiCorso(Corso corso, Docente docente)
        {
            docente.idDocente = _context.Docenti.Count()+1;
            _context.Docenti.Add(docente);
            this.Save();
            corso.Docente = docente.idDocente;
            _context.Corsi.Add(corso);
        }

        public void EliminaCorso(string nomeCorso)
        {
            nomeCorso = nomeCorso.ToLower();
            Corso corso = OttieniCorso(nomeCorso);
            int idDocente = corso.Docente;
            Docente docente = OttieniDocente(idDocente);
            var presenze = _context.Presenze
                .Where(n => n.Corso == nomeCorso)
                .ToList();
            var lezioni = _context.Lezioni
                .Where(n => n.NomeCorso == nomeCorso)
                .ToList();
            _context.Entry(corso).State = EntityState.Deleted;
            foreach(var lezione in lezioni)
            {
                _context.Entry(lezione).State = EntityState.Deleted;
            }
            _context.Entry(docente).State = EntityState.Deleted;
            foreach (var presenza in presenze)
            {
                _context.Entry(presenza).State = EntityState.Deleted;
            }

        }

        private Corso OttieniCorso(string nome)
        {
            var corso = _context.Corsi
                .Where(n => n.NomeCorso == nome).FirstOrDefault();
            if( corso != null)
            {
                return corso;
            }
            throw new Exception("Il corso non esiste");
        }

        private Docente OttieniDocente(int idDocente)
        {
            return _context.Docenti
                .Where(n => n.idDocente == idDocente).First();
        }

        public void AggiungiLezione(Lezione lezione)
        {
            var corso = OttieniCorso(lezione.NomeCorso);
            var lezioniPresenti = _context.Lezioni
                .Where(n => n.NomeCorso == corso.NomeCorso)
                .ToList();
            double oreSegnate = 0;
            foreach(var lezioneSingola in lezioniPresenti)
            {
                var oreLezione = lezioneSingola.DataOraFine.TimeOfDay - lezioneSingola.DataOraInizio.TimeOfDay;
                oreSegnate += oreLezione.TotalHours;
            }
            if(oreSegnate < corso.NumeroOre)
            {
                var oreLezione = lezione.DataOraFine.TimeOfDay - lezione.DataOraInizio.TimeOfDay;
                if(oreSegnate + oreLezione.TotalHours <= corso.NumeroOre)
                {
                    _context.Lezioni.Add(lezione);
                }
                else
                {
                    throw new Exception("Impossibile aggiungere la lezione. Verrebbe superato il numero di ore del corso");
                }
            }
            else
            {
                throw new Exception("Impossibile aggiungere la lezione. Numero di ore del corso raggiunto");
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
