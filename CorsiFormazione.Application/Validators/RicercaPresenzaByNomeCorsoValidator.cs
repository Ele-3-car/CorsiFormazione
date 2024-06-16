using CorsiFormazione.Application.Models.Requests;
using FluentValidation;

namespace CorsiFormazione.Application.Validators
{
    public class RicercaPresenzaByNomeCorsoValidator : AbstractValidator<RicercaPresenzaByNomeCorsoRequest>
    {
        public RicercaPresenzaByNomeCorsoValidator()
        {
            RuleFor(r => r.NomeCorso)
                .NotNull()
                .WithMessage("Il nome del corso è obbligatorio (nullo)")
                .NotEmpty()
                .WithMessage("Il nome del corso è obbligatorio (vuoto)");

            RuleFor(r => r.NumeroPaginaVisualizzare)
                .NotNull()
                .WithMessage("Il numero della pagina che si vuole visualizzare è obbligatorio (nullo)")
                .WithMessage("Le pagine iniziano da 1")
                .NotEmpty()
                .WithMessage("Il numero della pagina che si vuole visualizzare è obbligatorio (vuoto)")
                .WithMessage("Le pagine iniziano da 1");

            RuleFor(r => r.PageSize)
                .NotNull()
                .WithMessage("La grandezza della pagina è obbligatoria (nullo)")
                .NotEmpty()
                .WithMessage("La grandezza della pagina è obbligatoria (vuoto)");
        }
    }
}
