using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Requests
{
    public class AggiungiPresenzaRequest
    {
        public string NomeAlunno { get; set; }
        public string CognomeAlunno { get; set; }
        public string Corso {  get; set; }
        public DateTime Ingresso { get; set; }
        public DateTime Uscita { get; set; }

        public Presenza ToEntity()
        {
            Presenza presenza = new Presenza();
            presenza.NomeAlunno = NomeAlunno.ToLower();
            presenza.CognomeAlunno = CognomeAlunno.ToLower();
            presenza.Ingresso = Ingresso;
            presenza.Uscita = Uscita;
            presenza.Corso = Corso.ToLower();

            return presenza;
        }
    }
}
