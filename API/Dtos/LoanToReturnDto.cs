namespace API.Dtos
{
    public class LoanToReturnDto
    {
        public string Name { get; set; }
        
        public float InterestPerYear { get; set; }
        
        public ushort MinDurationInMonths { get; set; }
        
        public ushort MaxDurationInMonths { get; set; }
        
        public uint MinAmount { get; set; }
        
        public uint MaxAmount { get; set; }
        
        
    }
}