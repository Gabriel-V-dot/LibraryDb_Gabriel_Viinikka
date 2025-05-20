using LibraryDb_Gabriel_Viinikka.DTOs.LoanerDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class LoanerDTOExtensions
    {
        public static LoanerDTO ToLoanerDTO(this Loaner loaner)
        {

            return new LoanerDTO
            {
                FirstName = loaner.FirstName,
                LastName = loaner.LastName
            };


        }

    }
}
