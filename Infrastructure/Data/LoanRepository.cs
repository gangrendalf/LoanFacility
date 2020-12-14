using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class LoanRepository : ILoanRepository
  {
    private readonly LoanFacilityContext _context;

    public LoanRepository(LoanFacilityContext context)
    {
      this._context = context;
    }

    public async Task<Loan> GetLoanAsync(string loanType)
    {
        var loan = await _context.Loans
            .Include(r => r.InterestPerYear)
            .FirstOrDefaultAsync(l => l.Name == loanType);

        return loan;
    }

    public async Task<IReadOnlyList<Loan>> GetLoansAsync()
    {
        var loans = await _context.Loans
            .Include(r => r.InterestPerYear)
            .ToListAsync();

        return loans;
    }
  }
}