using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
  public interface IScheduler
  {
    Schedule CreateSchedule(LoanApplication paybackData);
  }
}