using CorsiFormazione.Models.Entities;

namespace CorsiFormazione.Application.Models.Responses
{
    public class CreaCorsoResponse
    {
        public string EsitoOperazione { get; set; } = "Il corso è stato aggiunto con successo:";
        public Corso CorsoAggiunto { get; set; }

        public CreaCorsoResponse(Corso corso)
        {
            CorsoAggiunto = corso;
        }
    }
}
