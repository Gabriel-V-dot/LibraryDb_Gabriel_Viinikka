using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class InventoryDTOExtensions
    {

        public static Inventory BookTOInventory(this Book book)
        {
            return new Inventory
            {
                BookId = book.Id,
                Book = book,
                Available = true
            };
        }

        public static InventoryDTO InventoryToInventoryDTO(this Inventory inventory,Book book)
        {
            return new InventoryDTO
            {
                Id = inventory.Id,
                Book = book,
                Available = inventory.Available
            };
        }


    }
}
