using CinemaApp.Application.Requests;
using CinemaApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Application.Validators
{
    public class CreateSalaValidator : AbstractValidator<CreateSalaRequest>
    {
        public CreateSalaValidator()
        {
            RuleFor(x => x.Nomenclatura)
                .NotEmpty()
                .WithMessage("La nomenclatura es requerida");

            RuleFor(x => x.Capacidad)
                .NotEqual(0)
                .WithMessage("La capacidad debe ser superior a 0");
        }
    }
}
