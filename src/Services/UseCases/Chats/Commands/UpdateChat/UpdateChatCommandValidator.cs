using FluentValidation;

namespace UseCases.Chats.Commands.UpdateChat
{
    public class UpdateChatCommandValidator : AbstractValidator<UpdateChatCommand>
    {
        public UpdateChatCommandValidator()
        {
            RuleFor(x => x.Data.Id)
                .NotNull()
                    .WithMessage("Id is required")
                .GreaterThan(0)
                    .WithMessage("Id must be bigger than 0");

            RuleFor(x => x.Data.Name)
            .NotEmpty()
                .WithMessage("Name is required")
            .NotNull()
                .WithMessage("Name is required");
        }
    }
}
