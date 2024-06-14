using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Dtos
{
    public class PresenzaDto
    {
        public string NomeAlunno { get; set; }
        public string CognomeAlunno { get; set; }
        public DateTime Ingrezzo { get; set; }
        public DateTime Uscita { get; set; }

        public PresenzaDto() { }

        public PresenzaDto(Presenza presenza)
        {
            NomeAlunno = presenza.NomeAlunno;
            CognomeAlunno = presenza.CognomeAlunno;
            Ingrezzo = presenza.Ingrezzo;
            Uscita = presenza.Uscita;
        }
    }
}
