using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class CreateLoansDTO
    {
        public int InventoryId { get; set; }
        public required int LoanCardId { get; set; }
    }
}
