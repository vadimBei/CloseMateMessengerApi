using FluentValidation;

namespace UseCases.ChatCompletions.Commands.DeleteChatCompletion
{
    public class DeleteChatCompletionCommandValidator : AbstractValidator<DeleteChatCompletionCommand>
    {
        public DeleteChatCompletionCommandValidator()
        {
            RuleFor(x => x.Id)
                   .NotNull()
                       .WithMessage("Id is required")
                   .GreaterThan(0)
                       .WithMessage("Id must be bigger than 0");
        }
    }
}
