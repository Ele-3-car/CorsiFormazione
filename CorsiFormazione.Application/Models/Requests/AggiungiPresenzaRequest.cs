﻿using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Requests
{
    public class AggiungiPresenzaRequest
    {
        public string NomeAlunno { get; set; }
        public string CognomeAlunno { get; set; }
        public string Corso {  get; set; }
        public DateTime Ingrezzo { get; set; }
        public DateTime Uscita { get; set; }

        public Presenza ToEntity()
        {
            Presenza presenza = new Presenza();
            presenza.NomeAlunno = NomeAlunno;
            presenza.CognomeAlunno = CognomeAlunno;
            presenza.Ingrezzo = Ingrezzo;
            presenza.Uscita = Uscita;

            return presenza;
        }
    }
}
