using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Core.Interfaces;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LoanController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ILoanRepository _loanRepo;
    private readonly ISchedule _paybackSchedule;

    public LoanController(ILoanRepository loanRepo, ISchedule paybackSchedule, IMapper mapper)
    {
      this._mapper = mapper;
      this._loanRepo = loanRepo;
      this._paybackSchedule = paybackSchedule;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LoanToReturnDto>>> GetLoans()
    {
      var loans = await _loanRepo.GetLoansAsync();

      return Ok(_mapper.Map<IReadOnlyList<Loan>, IReadOnlyList<LoanToReturnDto>>(loans));
    }

    [HttpGet]
    [Route("offers")]
    public async Task<ActionResult<IReadOnlyList<LoanOffer>>> GetOffers()
    {
        var offers = await _loanRepo.GetOffers();

        return Ok(offers);
    }

    [HttpGet]
    [Route("{loanType}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LoanToReturnDto>> GetLoan(string loanType)
    {
      var loan = await _loanRepo.GetLoanAsync(loanType);

      if(loan == null)
        return NotFound();

      return _mapper.Map<Loan, LoanToReturnDto>(loan);
    }

    [HttpGet]
    [Route("{loanType}/paybackplan")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IScheduleData> GetPaybackSchedule([FromQuery] LoanApplication data, string loanType)
    {
      if(data == null | data.Amount == 0 | data.AnnualInterest == 0 | data.DurationInMonths == 0 | data.PayoffsPerYear == 0)
        return BadRequest();

      var scheduleData = _paybackSchedule.CreateSchedule(data);

      return Ok(scheduleData);
    }
  }
}