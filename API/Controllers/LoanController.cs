using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Models;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult<LoanToReturnDto>> GetLoan(string loanType)
    {
      var loan = await _loanRepo.GetLoanAsync(loanType);

      return _mapper.Map<Loan, LoanToReturnDto>(loan);
    }

    [HttpGet]
    [Route("{loanType}/paybackplan")]
    public ActionResult<IScheduleData> GetPaybackSchedule([FromQuery] LoanApplication data, string loanType)
    {
      var scheduleData = _paybackSchedule.CreateSchedule(data);

      return Ok(scheduleData);
    }
  }
}