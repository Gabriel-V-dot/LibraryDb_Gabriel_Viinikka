using LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class LoansDTOExtensions
    {

        public static ActiveLoanDTO ToActiveLoanDTO(this Loan loan)
        {
            return new ActiveLoanDTO
            {
                Id = loan.Id,
                LoanDate = DateOnly.FromDateTime(loan.LoanDate),  //new DateOnly (loan.LoanDate.Year,loan.LoanDate.Month,loan.LoanDate.Day),
                ExpectedReturnDate = DateOnly.FromDateTime(loan.LoanDate.AddDays(loan.Inventory.DaysToLoan)), // new DateOnly(loan.LoanDate.Year, loan.LoanDate.Month, loan.LoanDate.Day + loan.Inventory.DaysToLoan),
                Inventory = loan.Inventory.ToMinimalInventoryDTO(),
                LoanCard = loan.LoanCard.ToMinimalLoanCardDTO(),
                DaysToLoan = (int)(loan.LoanDate.AddDays(loan.Inventory.DaysToLoan) - loan.LoanDate).TotalDays  //(int)(loan.LoanDate - loan.LoanDate.AddDays(loan.Inventory.DaysToLoan)).TotalDays
            };
        }
        public static ReturnedLoanDTO ToReturnLoanDTO(this Loan loan)
        {
            return new ReturnedLoanDTO
            {
                Id = loan.Id,
                LoanDate = DateOnly.FromDateTime(loan.LoanDate),  //new DateOnly(loan.LoanDate.Year, loan.LoanDate.Month, loan.LoanDate.Day),
                ReturnDate = DateOnly.FromDateTime((DateTime)loan.ReturnDate!),
                Inventory = loan.Inventory.ToMinimalInventoryDTO(),
                LoanCard = loan.LoanCard.ToMinimalLoanCardDTO(),
                DaysLeft = (int)(loan.LoanDate.AddDays(loan.Inventory.DaysToLoan) - (DateTime)loan.ReturnDate).TotalDays// (int)((DateTime)loan.ReturnDate! - (loan.LoanDate.AddDays(loan.Inventory.DaysToLoan))).TotalDays // reaturndate - (expexcted returndate)(loandate + daystoloan)    // (int)(loan.LoanDate - loan.LoanDate.AddDays(loan.Inventory.DaysToLoan - 1)).TotalDays
            };
        }



    }
}
