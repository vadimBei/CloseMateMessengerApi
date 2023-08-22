using FluentValidation;

namespace UseCases.ChatMessages.Commands.SendMessage
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator()
        {
            RuleFor(x => x.Data.ChatId)
               .NotNull()
                   .WithMessage("ChatId is required")
               .GreaterThan(0)
                   .WithMessage("ChatId must be bigger than 0");

            RuleFor(x => x.Data.Content)
               .NotEmpty()
                   .WithMessage("Content is required")
               .NotNull()
                   .WithMessage("Content is required");
        }
    }
}
