using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs
{
    public class CreateLoanCardDTO
    {
        public int LoanerId { get; set; }
        public int ValidTime { get; set; }
    }
}
