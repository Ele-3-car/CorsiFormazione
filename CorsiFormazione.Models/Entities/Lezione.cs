using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Entities
{
    public class Lezione
    {
        public string NomeCorso {  get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo {  get; set; }
        public ModoErogazione Erogazione { get; set; }

        public Corso CorsoAssociato { get; set; }
        public ICollection<Presenza> Presenze { get; set; }
    }
}
