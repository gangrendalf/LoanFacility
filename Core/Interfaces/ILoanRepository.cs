using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ILoanRepository
    {
        Task<IReadOnlyList<LoanOffer>> GetOffers();
        Task<IReadOnlyList<Loan>> GetLoansAsync();
        Task<Loan> GetLoanAsync(string loanType);
    }
}