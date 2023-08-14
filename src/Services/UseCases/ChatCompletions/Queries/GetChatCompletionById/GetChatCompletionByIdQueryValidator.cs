using FluentValidation;

namespace UseCases.ChatCompletions.Queries.GetChatCompletionById
{
    public class GetChatCompletionByIdQueryValidator : AbstractValidator<GetChatCompletionByIdQuery>
    {
        public GetChatCompletionByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                    .WithMessage("Id is required")
                .GreaterThan(0)
                    .WithMessage("Id must be bigger than 0");
        }
    }
}
