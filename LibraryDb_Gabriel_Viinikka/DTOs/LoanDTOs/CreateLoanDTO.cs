using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    /// <summary>
    /// InventoryId and LoanCardId 
    /// </summary>
    public class CreateLoanDTO
    {
        public int InventoryId { get; set; }
        public required int LoanCardId { get; set; }
    }
}
