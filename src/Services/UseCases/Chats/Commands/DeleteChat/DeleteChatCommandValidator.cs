using FluentValidation;

namespace UseCases.Chats.Commands.DeleteChat
{
    public class DeleteChatCommandValidator : AbstractValidator<DeleteChatCommand>
    {
        public DeleteChatCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                    .WithMessage("Id is required")
                .GreaterThan(0)
                    .WithMessage("Id must be bigger than 0");
        }
    }
}
