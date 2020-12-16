using Core.Entities;

namespace Core.Interfaces
{
  public interface IScheduleData
  {
    string Title { get; }
    float TotalToPay { get; }
    float TotalInterestToPay { get; }

    IScheduleRowData[] Schedule { get; }
    
    LoanApplication Application { get; }
  }
}