﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Models.Entities
{
    public class Presenza
    {
        public string NomeAlunno { get; set; }
        public string CognomeAlunno { get; set; }
        public DateTime Ingresso { get; set; }
        public DateTime Uscita { get; set; }
        public string Corso { get; set; }

        public Lezione LezioneDiRiferimento { get; set; }
    }
}
