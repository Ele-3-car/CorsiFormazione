using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Dtos
{
    public class PresenzaDto
    {
        public string NomeAlunno { get; set; }
        public string CognomeAlunno { get; set; }
        public DateTime Ingresso { get; set; }
        public DateTime Uscita { get; set; }

        public PresenzaDto() { }

        public PresenzaDto(Presenza presenza)
        {
            NomeAlunno = presenza.NomeAlunno;
            CognomeAlunno = presenza.CognomeAlunno;
            Ingresso = presenza.Ingresso;
            Uscita = presenza.Uscita;
        }
    }
}


