using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Entities
{
    public class Corso
    {
        public string NomeCorso { get; set; }
        public int Docente { get; set; }
        public int NumeroOre { get; set; }

        public ICollection<Lezione> Lezioni { get; set; }
    }
}
