using FluentValidation;

namespace UseCases.ChatCompletions.Commands.CreateChatCompletion
{
    public class CreateChatCompletionCommandValidator : AbstractValidator<CreateChatCompletionCommand>
    {
        public CreateChatCompletionCommandValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty()
                    .WithMessage("Message is required")
                .NotNull()
                    .WithMessage("Message is required");
        }
    }
}
