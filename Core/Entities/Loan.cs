namespace Core.Entities
{
  public class Loan
  {
    public int Id { get; set; }
    
    public string Name { get; set; }

    public Rate InterestPerYear { get; set; }

    public int InterestPerYearId { get; set; }

    public ushort MinDurationInMonths { get; set; }

    public ushort MaxDurationInMonths { get; set; }

    public uint MinAmount { get; set; }

    public uint MaxAmount { get; set; }

  }
}