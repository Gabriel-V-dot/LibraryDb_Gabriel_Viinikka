using Humanizer;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanerDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class LoanCardDTOExtensions
    {

        public static LoanCard ToLoanCard(this CreateLoanCardDTO createLoanCardDTO, Loaner loaner)
        {
            return new LoanCard
            {
                Loaner = loaner,
                LoanerId = loaner.Id,
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(createLoanCardDTO.ValidTime),
                IsActive = true
            };
        }

        public static LoanCardDTO ToLoanCardDTO(this LoanCard loanCard)
        {
            return new LoanCardDTO
            {
                Id = loanCard.Id,
                Loaner = loanCard.Loaner?.ToCreateLoanerDTO(),
                ExpirationDate = DateOnly.FromDateTime(loanCard.ExpirationDate),
                IsActive = loanCard.IsActive
            };
        }

        public static MinimalLoanCardDTO ToMinimalLoanCardDTO(this LoanCard loanCard)
        {
            return new MinimalLoanCardDTO
            {
                Loaner = loanCard.Loaner?.ToCreateLoanerDTO()
            };
        }


    }
}
