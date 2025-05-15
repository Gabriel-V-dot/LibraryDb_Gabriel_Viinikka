using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs
{
    public class CreateAuthorDTO
    {
        public required string FirstName { get; set; }
        public required string LastName {get; set; }
        public List<int> BookId { get; set; } = [];
    }

}
