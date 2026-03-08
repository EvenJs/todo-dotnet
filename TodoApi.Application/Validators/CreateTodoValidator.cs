using FluentValidation;
using TodoApi.Application.DTOs;

namespace TodoApi.Application.Validators;

public class CreateTodoValidator : AbstractValidator<CreateTodoDto>
{
  public CreateTodoValidator()
  {
    RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

    RuleFor(x => x.Tag).NotEmpty().WithMessage("Tag is required.").MaximumLength(50).WithMessage("Tag must not exceed 50 characters.");

    RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters").When(x=>x.Description is not null);
  }
}