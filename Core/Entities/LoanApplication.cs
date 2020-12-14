namespace Core.Entities
{
  public class LoanApplication
  {
    public int Amount { get; set; }
    public float AnnualInterest { get; set; }

    public int DurationInMonths { get; set; }

    public int PayoffsPerYear { get; set; }
  }
}