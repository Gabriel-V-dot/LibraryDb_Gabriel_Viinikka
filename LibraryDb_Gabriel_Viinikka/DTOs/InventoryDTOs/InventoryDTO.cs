using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public required Book Book { get; set; }
        public bool Available { get; set; }
        public int DaysToLoan { get; set; }
    }
}
            