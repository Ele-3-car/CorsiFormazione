using CorsiFormazione.Application.Models.Requests;
using FluentValidation;

namespace CorsiFormazione.Application.Validators
{
    public class AggiungiPresenzaValidator : AbstractValidator<AggiungiPresenzaRequest>
    {
        public AggiungiPresenzaValidator()
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

            RuleFor(r => r.Ingresso)
                .NotNull()
                .WithMessage("La data e ora di ingresso dell'alunno/a sono obbligatorie (nullo)")
                .NotEmpty()
                .WithMessage("La data e ora di ingresso dell'alunno/a sono obbligatorie (vuoto)");

            RuleFor(r => r.Uscita)
                .NotNull()
                .WithMessage("La data e ora di uscita dell'alunno/a sono obbligatorie (nullo)")
                .NotEmpty()
                .WithMessage("La data e ora di uscita dell'alunno/a sono obbligatorie (vuoto)");
        }
    }
}
