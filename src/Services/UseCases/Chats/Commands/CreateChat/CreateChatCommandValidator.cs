using FluentValidation;

namespace UseCases.Chats.Commands.CreateChat
{
    public class CreateChatCommandValidator : AbstractValidator<CreateChatCommand>
    {
        public CreateChatCommandValidator()
        {
            RuleFor(x => x.Data.Message)
                .NotEmpty()
                    .WithMessage("Message is required")
                .NotNull()
                    .WithMessage("Message is required");
        }
    }
}
