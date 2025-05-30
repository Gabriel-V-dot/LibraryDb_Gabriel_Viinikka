using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs
{
    public class MinimalInventoryDTO
    {
        public int Id { get; set; }
        public required MinimalBookDTO Book { get; set; }
    }
}
