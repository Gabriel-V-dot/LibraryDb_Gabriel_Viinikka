using LibraryDb_Gabriel_Viinikka.DTOs.LoanerDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class LoanerDTOExtensions
    {
        public static Loaner ToLoaner(this LoanerDTO loanerDTO)
        {

            return new Loaner
            {
                FirstName = loanerDTO.FirstName,
                LastName = loanerDTO.LastName
            };


        }

    }
}
