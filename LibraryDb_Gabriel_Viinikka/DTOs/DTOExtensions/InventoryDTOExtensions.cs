using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class InventoryDTOExtensions
    {

        public static Inventory ToInventory(this CreateInventoryDTO createInventoryDTO, Book book)
        {
            return new Inventory
            {
                BookId = book.Id,
                Book = book,
                Available = true,
                DaysToLoan = createInventoryDTO.DaysToLoan
            };
        }

        public static InventoryDTO ToInventoryDTO(this Inventory inventory)
        {
            return new InventoryDTO
            {
                Id = inventory.Id,
                Book = inventory.Book,
                Available = inventory.Available,
                DaysToLoan = inventory.DaysToLoan
            };
        }
        public static MinimalInventoryDTO ToMinimalInventoryDTO(this Inventory inventory)
        {
            return new MinimalInventoryDTO 
            {
                Id = inventory.Id,
                Book = inventory.Book.ToMinimalBookDTO()
            };
        }

    }
}
