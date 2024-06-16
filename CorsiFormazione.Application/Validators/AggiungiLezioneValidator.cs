using CorsiFormazione.Application.Models.Requests;
using FluentValidation;

namespace CorsiFormazione.Application.Validators
{
    public class AggiungiLezioneValidator : AbstractValidator<AggiungiLezioneRequest>
    {
        public AggiungiLezioneValidator()
        {
            RuleFor(r => r.NomeCorso)
                .NotNull()
                .WithMessage("Il nome del corso è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome del corso è obbligatorio (vuoto)");

            RuleFor(r => r.DataOraInizio)
                .NotNull()
                .WithMessage("La data e ora di inizio lezione sono obbligatorie (nullo)")
                .NotEmpty()
                .WithMessage("La data e ora di inizio lezione sono obbligatorie (vuoto)");

            RuleFor(r => r.DataOraFine)
                .NotNull()
                .WithMessage("La data e ora di fine lezione sono obbligatorie (nullo)")
                .NotEmpty()
                .WithMessage("La data e ora di fine lezione sono obbligatorie (vuoto)");

            RuleFor(r => r.Luogo)
                .NotNull()
                .WithMessage("Il luogo della lezione è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il luogo della lezione è obbligatorio (vuoto)");

            RuleFor(r => r.Erogazione)
                .NotNull()
                .WithMessage("La modalità di erogazione della lezione è obbligatoria (nullo)")
                .WithMessage("Inserire 1 se in Presenza, 2 se da Remoto")
                .NotEmpty()
                .WithMessage("La data e ora di inizio lezione è obbligatoria (vuoto)")
                .WithMessage("Inserire 1 se in Presenza, 2 se da Remoto");
        }
    }
}
