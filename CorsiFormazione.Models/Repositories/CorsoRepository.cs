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

        public void AggiungiCorso(Corso corso, Docente docente, CalendarioLezioni lezioni)
        {
            docente.idDocente = _context.Docenti.Count()+1;
            _context.Docenti.Add(docente);
            lezioni.IdCalendario = _context.Lezioni.Count()+1;
            _context.Lezioni.Add(lezioni);
            this.Save();
            corso.Docente = docente.idDocente;
            corso.Lezioni = lezioni.IdCalendario;
            _context.Corsi.Add(corso);
        }

        public void EliminaCorso(string nomeCorso)
        {
            Corso corso = OttieniCorso(nomeCorso);
            int idCalendario = corso.Lezioni;
            CalendarioLezioni calentario = OttieniCalendario(idCalendario);
            int idDocente = corso.Docente;
            Docente docente = OttieniDocente(idDocente);
            _context.Entry(corso).State = EntityState.Deleted;
            _context.Entry(calentario).State = EntityState.Deleted;
            _context.Entry(docente).State = EntityState.Deleted;

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

        private CalendarioLezioni OttieniCalendario(int idCalendario)
        {
            var calendario = _context.Lezioni
                .Where(n => n.IdCalendario == idCalendario).FirstOrDefault();
            //return calendario;
            if (calendario != null)
            {
                return calendario;
            }
            throw new Exception("Il calendario non esiste");
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
