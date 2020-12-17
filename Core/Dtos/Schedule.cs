using Core.Entities;

namespace Core.Dtos
{
    public class Schedule
    {
        public string Title { get; set; }
        
        public float TotalToPay { get; set; }
        
        public float TotalInterestToPay { get; set; }
        
        public ScheduleRow[] ScheduleTable { get; set; }
        public LoanApplication Application { get; set; }
        
        
    }
}