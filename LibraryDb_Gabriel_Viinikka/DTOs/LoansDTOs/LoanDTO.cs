using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class LoanDTO
    {
        public int Id { get; set; }
        public required DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public MinimalInventoryDTO? Inventory { get; set; }
        public required MinimalLoanCardDTO LoanCard { get; set; }
        public int DaysLeft { get; set; }
    }
}
