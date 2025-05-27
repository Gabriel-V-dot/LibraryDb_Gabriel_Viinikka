using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class LoansDTO
    {
        public int Id { get; set; }
        public required DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public required Inventory InventoryBook { get; set; }
        public required LoanCard LoanCardReference { get; set; }
    }
}
