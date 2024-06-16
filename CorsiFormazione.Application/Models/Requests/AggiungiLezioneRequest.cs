using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Requests
{
    public class AggiungiLezioneRequest
    {
        public string NomeCorso { get; set; }
        public DateTime DataOraInizio { get; set; }
        public DateTime DataOraFine { get; set; }
        public string Luogo { get; set; }
        public ModoErogazione Erogazione { get; set; }

        public Lezione ToEntity()
        {
            Lezione lezione = new Lezione();
            lezione.NomeCorso = NomeCorso.ToLower();
            lezione.DataOraInizio = DataOraInizio;
            lezione.DataOraFine = DataOraFine;
            lezione.Luogo = Luogo.ToLower();
            lezione.Erogazione = Erogazione;

            return lezione;
        }
    }
}
