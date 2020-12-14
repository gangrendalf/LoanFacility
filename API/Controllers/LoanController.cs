using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
    private readonly LoanFacilityContext _context;

    public LoanController(LoanFacilityContext context)
        {
      this._context = context;
    }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LoanToReturnDto>>> GetLoans()
        {
            var loans = await _context.Loans
                .Include(r => r.InterestPerYear)
                .ToListAsync(); 
            
            return loans.Select(loan => new LoanToReturnDto
            {
                Name = loan.Name,
                InterestPerYear = loan.InterestPerYear.Interest,
                MinDurationInMonths = loan.MinDurationInMonths,
                MaxDurationInMonths = loan.MaxDurationInMonths,
                MinAmount = loan.MinAmount,
                MaxAmount = loan.MaxAmount
            }).ToList();
        }

        [HttpGet]
        [Route("{loanType}")]
        public async Task<ActionResult<LoanToReturnDto>> GetLoan(string loanType)
        {
            var loan = await _context.Loans
                .Include(r => r.InterestPerYear)
                .FirstOrDefaultAsync(l => l.Name == loanType);
        
            return new LoanToReturnDto
            {
                Name = loan.Name,
                InterestPerYear = loan.InterestPerYear.Interest,
                MinDurationInMonths = loan.MinDurationInMonths,
                MaxDurationInMonths = loan.MaxDurationInMonths,
                MinAmount = loan.MinAmount,
                MaxAmount = loan.MaxAmount
            };
        }
    }
}