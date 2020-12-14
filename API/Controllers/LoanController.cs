using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IReadOnlyList<Loan>>> GetLoans()
        {
            return await _context.Loans
                .Include(r => r.InterestPerYear)
                .ToListAsync();
        }

        [HttpGet]
        [Route("{loanType}")]
        public async Task<ActionResult<Loan>> GetLoan(string loanType)
        {
            return await _context.Loans
                .Include(r => r.InterestPerYear)
                .FirstOrDefaultAsync(l => l.Name == loanType);
        }
    }
}