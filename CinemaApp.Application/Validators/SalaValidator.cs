using CinemaApp.Application.Requests;
using FluentValidation;

namespace CinemaApp.Application.Validators
{
    public class SalaValidator : AbstractValidator<CreateSalaRequest>
    {
        public SalaValidator()
        {
            RuleFor(sala => sala.Nomenclatura)
                .NotEmpty()
                .WithMessage("La nomenclatura es requerida Test");
        }
    }
}
