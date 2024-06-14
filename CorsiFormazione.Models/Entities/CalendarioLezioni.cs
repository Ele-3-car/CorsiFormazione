using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Entities
{
    public class CalendarioLezioni
    {
        public int IdCalendario {  get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo {  get; set; }
        public ModoErogazione Erogazione { get; set; }
    }
}
