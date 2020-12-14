using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
        CreateMap<Loan, LoanToReturnDto>()
            .ForMember(d => d.InterestPerYear, o => o.MapFrom(s => s.InterestPerYear.Interest));
    }
  }
}