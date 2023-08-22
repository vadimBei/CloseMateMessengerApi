using FluentValidation;

namespace UseCases.Chats.Queries.GetChatById
{
    public class GetChatByIdQueryValidator : AbstractValidator<GetChatByIdQuery>
    {
        public GetChatByIdQueryValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
                   .WithMessage("Id is required")
               .GreaterThan(0)
                   .WithMessage("Id must be bigger than 0");
        }
    }
}
