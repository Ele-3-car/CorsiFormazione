using CorsiFormazione.Application.Models.Requests;
using FluentValidation;

namespace CorsiFormazione.Application.Validators
{
    public class EliminaPresenzaValidator : AbstractValidator<EliminaPresenzaRequest>
    {
        public EliminaPresenzaValidator()
        {
            RuleFor(r => r.Corso)
                .NotNull()
                .WithMessage("Il nome del corso è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome del corso è obbligatorio (vuoto)");

            RuleFor(r => r.NomeAlunno)
                .NotNull()
                .WithMessage("Il nome dell'alunno/a è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome dell'alunno/a è obbligatorio (vuoto)");

            RuleFor(r => r.CognomeAlunno)
                .NotNull()
                .WithMessage("Il cognome dell'alunno/a è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il cognome dell'alunno/a è obbligatorio (vuoto)");

            RuleFor(r => r.Data)
                .NotNull()
                .WithMessage("La data della presenza da eliminare è obbligatoria (nullo)")
                .NotEmpty()
                .WithMessage("La data della presenza da eliminare è obbligatoria (vuoto)");
        }
    }
}
