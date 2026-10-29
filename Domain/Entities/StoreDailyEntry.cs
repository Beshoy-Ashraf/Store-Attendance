namespace Domain.Entities;

public class StoreDailyEntry
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public DateOnly Date { get; set; }

    // Acquisition
    public int AcqLowAchieved { get; set; }
    public int AcqHighAchieved { get; set; }
    public int CashNewAchieved { get; set; }

    // Terminal
    public decimal TerminalAchieved { get; set; }

    // DSL & Connectivity
    public int DslAchieved { get; set; }
    public int ConnectivityAchieved { get; set; }

    // Enterprise
    public int EnterpriseNewAccountAchieved { get; set; }
    public int EnterpriseGaAchieved { get; set; }

    // NID Lines — Morning shift
    public int AmOneLine { get; set; }
    public int AmTwoLines { get; set; }
    public int AmThreeLines { get; set; }

    // NID Lines — Evening shift
    public int PmOneLine { get; set; }
    public int PmTwoLines { get; set; }
    public int PmThreeLines { get; set; }

    // Other activations
    public int Mnp { get; set; }
    public int NewRed { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    // Navigation
    public Store Store { get; set; } = default!;
}
