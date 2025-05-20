using LibraryDb_Gabriel_Viinikka.DTOs.LoanerDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs
{
    public class LoanCardDTO
    {
        public int Id { get; set; }
        public required LoanerDTO Loaner { get; set; }
        public required DateOnly ExpirationDate { get; set; }
        public bool IsActive { get; set; }

    }
}
