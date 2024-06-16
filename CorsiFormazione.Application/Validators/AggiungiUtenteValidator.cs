using CorsiFormazione.Application.Models.Requests;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CorsiFormazione.Application.Validators
{
    public class AggiungiUtenteValidator : AbstractValidator<AggiungiUtenteRequest>
    {
        public AggiungiUtenteValidator()
        {
            RuleFor(r => r.UtenteEmail)
                .NotNull()
                .WithMessage("L'email è obbligatoria (nullo)")
                .NotEmpty()
                .WithMessage("L'email è obbligatoria (vuoto)")
                .Custom((value, context) =>
                {
                    var regEx = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                    if (regEx.IsMatch(value) == false)
                    {
                        context.AddFailure("L'email inserita non è in un formato valido");
                    }
                });

            RuleFor(r => r.Password)
                    .NotNull()
                    .WithMessage("La password è obbligatoria (nullo)")
                    .NotEmpty()
                    .WithMessage("La password è obbligatoria (vuoto)")
                    .MinimumLength(5)
                    .WithMessage("La password deve essere lunga almeno 5 caratteri")
                    .Custom((value, context) =>
                    {
                        var regEx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{5,}$");
                        if (regEx.IsMatch(value) == false)
                        {
                            context.AddFailure("La password deve essere lunga almeno 5 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale");
                        }
                    });
        }
    }
}
