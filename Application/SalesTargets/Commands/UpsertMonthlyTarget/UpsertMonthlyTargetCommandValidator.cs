using FluentValidation;

namespace Application.SalesTargets.Commands.UpsertMonthlyTarget;

public class UpsertMonthlyTargetCommandValidator : AbstractValidator<UpsertMonthlyTargetCommand>
{
    public UpsertMonthlyTargetCommandValidator()
    {
        RuleFor(x => x.StoreId).NotEmpty();
        RuleFor(x => x.Year).InclusiveBetween(2020, 2100);
        RuleFor(x => x.Month).InclusiveBetween(1, 12);
        RuleFor(x => x.AcqLow).GreaterThanOrEqualTo(0);
        RuleFor(x => x.AcqHigh).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CashNew).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Terminal).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Dsl).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Connectivity).GreaterThanOrEqualTo(0);
        RuleFor(x => x.EnterpriseNewAccount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.EnterpriseGa).GreaterThanOrEqualTo(0);
    }
}
