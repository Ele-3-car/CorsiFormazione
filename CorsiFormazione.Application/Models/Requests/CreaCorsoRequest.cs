using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Requests
{

    public class DocenteNoID
    {
        public string NomeDocente { get; set; }
        public string CognomeDocente { get; set; }
    }

    public class CreaCorsoRequest
    {
        public string NomeCorso { get; set; }
        public DocenteNoID Docente { get; set; }
        public int NumeroOre { get; set; }

        public Corso ToEntityCorso()
        {
            Corso corso = new Corso();
            corso.NomeCorso = NomeCorso.ToLower();
            corso.NumeroOre = NumeroOre;

            return corso;
        }

        public Docente ToEntityDocente()
        {
            Docente docente = new Docente();
            docente.NomeDocente = Docente.NomeDocente.ToLower();
            docente.CognomeDocente = Docente.CognomeDocente.ToLower();

            return docente;
        }
    }
}
