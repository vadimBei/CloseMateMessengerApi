using FluentValidation;

namespace UseCases.ChatCompletions.Commands.UpdateChatCompletion
{
    public class UpdateChatCompletionCommandValidator : AbstractValidator<UpdateChatCompletionCommand>
    {
        public UpdateChatCompletionCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                    .WithMessage("Id is required")
                .GreaterThan(0)
                    .WithMessage("Id must be bigger than 0");

                RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .NotNull()
                    .WithMessage("Name is required");
        }
    }
}
