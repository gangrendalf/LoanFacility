using Core.Interfaces;

namespace Core.Models
{
    public class ScheduleData : IScheduleData
    {
        public string Title { get; set; }
        
        public float TotalToPay { get; set; }
        
        public float TotalInterestToPay { get; set; }
        
        public IScheduleRowData[] Schedule { get; set; }
        
        
    }
}