namespace Domain.Entities;

public class StoreMonthlyTarget
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }

    public int AcqLow { get; set; }
    public int AcqHigh { get; set; }
    public int CashNew { get; set; }
    public decimal Terminal { get; set; }
    public int Dsl { get; set; }
    public int Connectivity { get; set; }
    public int EnterpriseNewAccount { get; set; }
    public int EnterpriseGa { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    // Navigation
    public Store Store { get; set; } = default!;
}
