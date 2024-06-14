using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Requests
{

    public class DocenteNoID
    {
        public string NomeDocente { get; set; }
        public string CognomeDocente { get; set; }
    }

    public class CalendarioNoPresenzeID
    {
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo { get; set; }
        public ModoErogazione Erogazione { get; set; }
    }

    public class CreaCorsoRequest
    {
        public string NomeCorso { get; set; }
        public DocenteNoID Docente { get; set; }
        public int NumeroOre { get; set; }

        public CalendarioNoPresenzeID Calendario { get; set; }
        //public ICollection<CalendarioLezioni> Lezioni { get; set; }

        public Corso ToEntity()
        {
            Corso corso = new Corso();
            corso.NomeCorso = NomeCorso;
            corso.NumeroOre = NumeroOre;
            //corso.Lezioni = Lezioni;

            return corso;
        }

        public Docente ToEntityDocente()
        {
            Docente docente = new Docente();
            docente.NomeDocente = Docente.NomeDocente;
            docente.CognomeDocente = Docente.CognomeDocente;

            return docente;
        }

        public CalendarioLezioni ToEntityCalendario()
        {
            CalendarioLezioni calendario = new CalendarioLezioni();
            calendario.DataOraInizio = Calendario.DataOraInizio;
            calendario.DataOraFine = Calendario.DataOraFine;
            calendario.Luogo = Calendario.Luogo;
            calendario.Erogazione = Calendario.Erogazione;

            return calendario;
        }
    }
}
