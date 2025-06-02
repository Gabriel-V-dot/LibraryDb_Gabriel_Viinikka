using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName {get; set; }

        public List<AuthorMinimalBookDTO> Books { get; set; } = [];
    }

}
