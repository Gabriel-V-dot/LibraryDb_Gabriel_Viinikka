using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs
{
    public class CreateBookDTO
    {
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public required DateOnly PublicationYear { get; set; }
        public required List<int> AuthorIds { get; set; } = [];
    }


}
