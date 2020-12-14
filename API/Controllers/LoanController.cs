using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public LoanController(LoanFacilityContext context, IMapper mapper)
        {
      this._context = context;
      this._mapper = mapper;
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
    }
}