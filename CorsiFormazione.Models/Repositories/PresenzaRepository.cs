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
            Controlli(presenza, corso);
            _context.Presenze.Add(presenza);
        }

        private void Controlli(Presenza presenza, string corso)
        {
            var controllaCorso = _context.Corsi
                .Where(n => n.NomeCorso == corso).FirstOrDefault();
            if(controllaCorso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            if (presenza.Ingrezzo.Date != presenza.Uscita.Date)
            {
                throw new Exception("Sono state inserite date diverse per l'ingresso e l'uscita");
            }
            var calendario = _context.Lezioni
                .Where(i => i.NomeCorso == corso)
                .Where(d => d.DataOraInizio.Date == presenza.Ingrezzo.Date)
                .FirstOrDefault();

            if(calendario == null)
            {
                throw new Exception("Non esistono lezioni per la data inserita");
            }

            var nomeECognome = _context.Presenze
                .Where(n => n.Corso == corso)
                .Where(n => n.NomeAlunno == presenza.NomeAlunno)
                .Where(n => n.CognomeAlunno == presenza.CognomeAlunno)
                .FirstOrDefault();

            if (nomeECognome != null)
            {
                throw new Exception($"La presenza per l'alunno {presenza.NomeAlunno} {presenza.CognomeAlunno} è già presente");
            }

            if (presenza.Ingrezzo.TimeOfDay < calendario.DataOraInizio.TimeOfDay ||
                presenza.Ingrezzo.TimeOfDay > calendario.DataOraFine.TimeOfDay)
            {
                throw new Exception($"Il corso non inizia prima delle {calendario.DataOraInizio.TimeOfDay}");
            }
            else if (presenza.Uscita.TimeOfDay > calendario.DataOraFine.TimeOfDay || 
                presenza.Uscita.TimeOfDay < calendario.DataOraInizio.TimeOfDay)
            {
                throw new Exception($"Il corso termina alle {calendario.DataOraFine.TimeOfDay}");
            }
        }

        public void EliminaPresenza(string nome, string cognome, string corsoNome, DateTime data)
        {
            nome = nome.ToLower();
            cognome = cognome.ToLower();
            corsoNome = corsoNome.ToLower();

            var corso = _context.Corsi
                .Where(n => n.NomeCorso == corsoNome).FirstOrDefault();
            if(corso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            var controlloAlunno = _context.Presenze
                .Where(p => p.NomeAlunno == nome)
                .Where(p => p.CognomeAlunno == cognome)
                .AsQueryable();

            if(controlloAlunno == null)
            {
                throw new Exception($"Nessuna presenza registrata a nome {nome} {cognome}");
            }

            var presenza = controlloAlunno.Where(p => p.Corso == corsoNome)
                .Where(p => p.Ingrezzo.Date.Equals(data.Date))
                .FirstOrDefault();

            if (presenza == null)
            {
                throw new Exception("La presenza non era stata inserita o c'è un'errore nella data inserita per la ricerca");
            }
            _context.Entry(presenza).State = EntityState.Deleted;
        }

        public List<Presenza> RicercaPresenzeCorso(int from, int num, int numeroPaginaVisualizzare, string corsoNome, out int totalNum)
        {
            corsoNome = corsoNome.ToLower();
            
            var corso = _context.Corsi
                .Where(n => n.NomeCorso == corsoNome).FirstOrDefault();
            if(corso == null)
            {
                throw new Exception("Il corso non esiste");
            }
            var query = _context.Presenze.AsQueryable();

            query = query.Where(w => w.Corso == corsoNome);

            totalNum = query.Count();
            if (numeroPaginaVisualizzare < 0 ||
                numeroPaginaVisualizzare > (int)Math.Ceiling(totalNum/(decimal)num))
            {
                throw new Exception($"La pagina che si vuole visualizzare non esiste. Le pagine vanno da 1 a {(int)Math.Ceiling(totalNum / (decimal)num)}");
            }
            
            var presenze = query
                .OrderBy(o => o.Ingrezzo.Date)
                .OrderBy(o => o.Ingrezzo.TimeOfDay)
                .Skip(from)
                .Take(num)
                .ToList();

            return presenze;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
