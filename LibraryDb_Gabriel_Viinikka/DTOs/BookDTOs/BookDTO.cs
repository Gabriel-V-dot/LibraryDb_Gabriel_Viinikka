using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs
{
    public class BookDTO
    {
        public required string Title { get; set; }

        public required string ISBN { get; set; }

        public required DateOnly PublicationYear { get; set; }

        public List<AuthorDTO> BookAuthors { get; set; } = new();

    }


}
