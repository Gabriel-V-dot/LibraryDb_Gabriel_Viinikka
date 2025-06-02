using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class ReturnedLoanDTO
    {
        public int Id { get; set; }
        public required DateOnly LoanDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public MinimalInventoryDTO? Inventory { get; set; }
        public required MinimalLoanCardDTO LoanCard { get; set; }
        public int DaysLeft { get; set; }
    }
}
