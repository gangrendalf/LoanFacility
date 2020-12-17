using Core.Interfaces;

namespace Core.Dtos
{
    public class ScheduleRow
    {
        public int MonthNo { get; set; }    
        public string Date { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double Payment { get; set; }
        public double Balance { get; set; }
    }
}