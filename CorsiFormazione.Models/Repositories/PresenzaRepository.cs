using CorsiFormazione.Models.Context;
using CorsiFormazione.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Repositories
{
    public class PresenzaRepository
    {
        private readonly MyDbContext _context;

        public PresenzaRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AggiungiPresenza(Presenza presenza, string corso)
        {
            
            CalendarioLezioni calendario = Controlli(presenza, corso);
            presenza.Calendario = calendario.IdCalendario;
            _context.Presenze.Add(presenza);
        }

        private CalendarioLezioni Controlli(Presenza presenza, string corso)
        {
            var controllaCorso = _context.Corsi
                .Where(n => n.NomeCorso == corso).FirstOrDefault();
            if (controllaCorso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            var calendario = _context.Lezioni
                .Where(i => i.IdCalendario == controllaCorso.Lezioni).First();
            if (presenza.Ingrezzo < calendario.DataOraInizio || presenza.Ingrezzo > calendario.DataOraFine)
            {
                throw new Exception($"Il corso non inizia prima delle {calendario.DataOraInizio.TimeOfDay}");
            }
            else if (presenza.Uscita > calendario.DataOraFine || presenza.Uscita < calendario.DataOraInizio)
            {
                throw new Exception($"Il corso termina alle {calendario.DataOraFine.TimeOfDay}");
            }

            if (presenza.Ingrezzo.Date < calendario.DataOraInizio.Date || presenza.Ingrezzo.Date > calendario.DataOraFine.Date)
            {
                throw new Exception($"Il corso inizia il {calendario.DataOraInizio.Date} e termina il {calendario.DataOraFine.Date}");
            }
            if (_context.Presenze.Count() != 0)
            {
                bool presente = _context.Presenze
                .ContainsAsync(presenza).Result;
                if (presente)
                {
                    throw new Exception("La presenza è già stata registrata");
                }
            }
            return calendario;
        }

        public void EliminaPresenza(string nome, string cognome, string corsoNome)
        {
            var corso = _context.Corsi
                .Where(n => n.NomeCorso == corsoNome).FirstOrDefault();
            if(corso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            var presenza = _context.Presenze
                .Where(p => p.NomeAlunno == nome)
                .Where(p => p.CognomeAlunno ==  cognome)
                .Where(p => p.Calendario == corso.Lezioni).FirstOrDefault();
            if(presenza == null)
            {
                throw new Exception("La presenza non era stata inserita");
            }
            _context.Entry(presenza).State = EntityState.Deleted;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Presenza> RicercaPresenzeCorso(int from, int num, string corsoNome, out int totalNum)
        {
            //TODO: finire
            var corso = _context.Corsi
                .Where(n => n.NomeCorso == corsoNome).FirstOrDefault();
            if(corso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            var query = _context.Presenze.AsQueryable();

            query = query.Where(w => w.Calendario == corso.Lezioni);
            /*if (!string.IsNullOrEmpty(corsoNome))
            {
                
            }*/

            totalNum = query.Count();
            
            var presenze = query
                .OrderBy(o => o.Ingrezzo.Date)
                .OrderBy(o => o.Ingrezzo.TimeOfDay)
                .Skip(from)
                .Take(num)
                .ToList();
            return presenze;
                
            /*var corso = _context.Corsi
                .Where(n => n.NomeCorso == corsoNome)
                .FirstOrDefault();
            if(corso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            var presenze = _context.Presenze
                .Where(i => i.Calendario == corso.Lezioni)
                .ToList();
            return presenze;*/
        }

        public List<Presenza> RicercaPresenzeDocente(string nome, string cognome)
        {
            throw new NotImplementedException();
        }

        public List<Presenza> RicercaPresenzeCorsoEData(string corso, DateOnly data)
        {
            throw new NotImplementedException();
        }

        public List<Presenza> RicercaPresenzeCorsoCognomeECorso(string cognome, string corso)
        {
            throw new NotImplementedException();
        }
    }
}
