using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
  public class LoanApplication
  {
    [Required]
    public int Amount { get; set; }
    [Required]
    public float AnnualInterest { get; set; }

    [Required]
    public int DurationInMonths { get; set; }

    [Required]
    public int PayoffsPerYear { get; set; }
  }
}