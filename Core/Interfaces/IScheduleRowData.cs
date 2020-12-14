namespace Core.Interfaces
{
    public interface IScheduleRowData
    {
        int MonthNo { get; }    
        string Date { get; }
        double Principal { get; }
        double Interest { get; }
        double Payment { get; }
        double Balance { get; }
    }
}