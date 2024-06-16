using CorsiFormazione.Application.Models.Requests;
using FluentValidation;

namespace CorsiFormazione.Application.Validators
{
    public class CreaCorsoValidator : AbstractValidator<CreaCorsoRequest>
    {
        public CreaCorsoValidator()
        {
            RuleFor(r => r.NomeCorso)
                .NotNull()
                .WithMessage("Il nome del corso è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome del corso è obbligatorio (vuoto)");

            RuleFor(r => r.Docente.NomeDocente)
                .NotNull()
                .WithMessage("Il nome del docente è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome del docente è obbligatorio (vuoto)");

            RuleFor(r => r.Docente.CognomeDocente)
                .NotNull()
                .WithMessage("Il cognome del docente è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il cognome del docente è obbligatorio (vuoto)");

            RuleFor(r => r.NumeroOre)
                .NotNull()
                .WithMessage("Il numero di ore totali del corso è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il numero di ore totali del corso è obbligatorio (vuoto)");
        }
    }
}
