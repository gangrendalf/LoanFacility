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
    private readonly LoanFacilityContext _context;
    private readonly IMapper _mapper;
    private readonly ISchedule _paybackSchedule;

    public LoanController(LoanFacilityContext context, ISchedule paybackSchedule, IMapper mapper)
        {
      this._context = context;
      this._mapper = mapper;
      this._paybackSchedule = paybackSchedule;
    }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LoanToReturnDto>>> GetLoans()
        {
            var loans = await _context.Loans
                .Include(r => r.InterestPerYear)
                .ToListAsync(); 
            
            return Ok(_mapper.Map<IReadOnlyList<Loan>, IReadOnlyList<LoanToReturnDto>>(loans));
        }

        [HttpGet]
        [Route("{loanType}")]
        public async Task<ActionResult<LoanToReturnDto>> GetLoan(string loanType)
        {
            var loan = await _context.Loans
                .Include(r => r.InterestPerYear)
                .FirstOrDefaultAsync(l => l.Name == loanType);
        
            return _mapper.Map<Loan, LoanToReturnDto>(loan);
        }

        [HttpGet]
        [Route("{loanType}/paybackplan")]
        public ActionResult<IScheduleData> GetPaybackSchedule([FromQuery]LoanApplication data, string loanType)
        {
            var scheduleData = _paybackSchedule.CreateSchedule(data);
            
            return Ok(scheduleData);
        }
    }
}