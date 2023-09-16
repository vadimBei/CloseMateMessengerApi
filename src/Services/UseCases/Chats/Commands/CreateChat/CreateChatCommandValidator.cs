using FluentValidation;

namespace UseCases.Chats.Commands.CreateChat
{
    public class CreateChatCommandValidator : AbstractValidator<CreateChatCommand>
    {
        public CreateChatCommandValidator()
        {
            RuleFor(x => x.Data.Name)
                .NotEmpty()
                    .WithMessage("Name is required")
                .NotNull()
                    .WithMessage("Name is required");
        }
    }
}
