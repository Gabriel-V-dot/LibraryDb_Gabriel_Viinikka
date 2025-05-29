using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.InventoryDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public required string ISBN { get; set; }

        public required DateOnly PublicationYear { get; set; }

        public double AverageRatings { get; set; }

        public List<MinimalAuthorDTO> BookAuthors { get; set; } = new();

        public int InventoryCount { get; set; }

    }


}
