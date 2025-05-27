using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class LoansDTO
    {
        public int Id { get; set; }
        public required DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public InventoryDTO? Inventory { get; set; }
        public LoanCardDTO? LoanCard { get; set; }
    }
}
