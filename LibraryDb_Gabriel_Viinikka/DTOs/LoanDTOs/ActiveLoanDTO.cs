using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.LoanCardDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class ActiveLoanDTO
    {
        public int Id { get; set; }
        public required DateOnly LoanDate { get; set; }
        public DateOnly? ExpectedReturnDate { get; set; }
        public MinimalInventoryDTO? Inventory { get; set; }
        public required MinimalLoanCardDTO LoanCard { get; set; }
        public int DaysToLoan { get; set; }
    }
}
