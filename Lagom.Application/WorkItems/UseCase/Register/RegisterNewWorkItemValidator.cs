using FluentValidation;
using Lagom.Communication.WorkItems;

namespace Lagom.Application.WorkItems.UseCase.Register;

public class RegisterNewWorkItemValidator : AbstractValidator<RegisterWorkItemRequest>
{
    public RegisterNewWorkItemValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título da tarefa é obrigatório.")
            .MaximumLength(100).WithMessage("O título da tarefa não pode exceder 100 caracteres.");

        RuleFor(x => x.DurationInMinutes)
            .GreaterThan(15).WithMessage("A duração da tarefa deve ser maior que 15 minutos.");
    }
}
