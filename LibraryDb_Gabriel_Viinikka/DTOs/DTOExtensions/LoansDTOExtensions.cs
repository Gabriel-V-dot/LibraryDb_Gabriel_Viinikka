using LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class LoansDTOExtensions
    {

        public static LoanDTO ToLoanDTO(this Loan loan)
        {
            return new LoanDTO
            {
                Id = loan.Id,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate,
                Inventory = loan.InventoryBook.ToInventoryDTO(loan.InventoryBook.Book),
                LoanCard = loan.LoanCard.ToLoanCardDTO()
            };
        }




    }
}
