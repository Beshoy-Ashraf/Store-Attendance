using FluentValidation;

namespace Application.SalesDailyEntries.Commands.UpsertDailyEntry;

public class UpsertDailyEntryCommandValidator : AbstractValidator<UpsertDailyEntryCommand>
{
    public UpsertDailyEntryCommandValidator()
    {
        RuleFor(x => x.StoreId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.AcqLowAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.AcqHighAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CashNewAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TerminalAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.DslAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ConnectivityAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.EnterpriseNewAccountAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.EnterpriseGaAchieved).GreaterThanOrEqualTo(0);
        RuleFor(x => x.AmOneLine).GreaterThanOrEqualTo(0);
        RuleFor(x => x.AmTwoLines).GreaterThanOrEqualTo(0);
        RuleFor(x => x.AmThreeLines).GreaterThanOrEqualTo(0);
        RuleFor(x => x.PmOneLine).GreaterThanOrEqualTo(0);
        RuleFor(x => x.PmTwoLines).GreaterThanOrEqualTo(0);
        RuleFor(x => x.PmThreeLines).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Mnp).GreaterThanOrEqualTo(0);
        RuleFor(x => x.NewRed).GreaterThanOrEqualTo(0);
    }
}
