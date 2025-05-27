using LibraryDb_Gabriel_Viinikka.DTOs.LoanerDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class LoanerDTOExtensions
    {
        public static CreateLoanerDTO? ToCreateLoanerDTO(this Loaner loaner)
        {

            if (loaner == null) return null;

            return new CreateLoanerDTO
            {
                FirstName = loaner.FirstName,
                LastName = loaner.LastName
            };


        }

        public static Loaner ToLoaner(this CreateLoanerDTO createLoanerDTO)
        {
            return new Loaner
            {
                FirstName = createLoanerDTO.FirstName,
                LastName = createLoanerDTO.LastName
            };
        }

    }
}
