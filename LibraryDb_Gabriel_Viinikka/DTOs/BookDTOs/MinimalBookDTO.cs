using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs
{
    public class MinimalBookDTO
    {
        public required string Title { get; set; }
        public required List<MinimalAuthorDTO> Authors { get; set; }
    }
}
