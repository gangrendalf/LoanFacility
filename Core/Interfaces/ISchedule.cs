using Core.Entities;

namespace Core.Interfaces
{
  public interface ISchedule
  {
    IScheduleData CreateSchedule(LoanApplication paybackData);
  }
}