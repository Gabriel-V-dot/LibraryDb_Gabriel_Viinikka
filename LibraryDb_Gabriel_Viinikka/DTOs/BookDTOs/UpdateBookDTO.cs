
namespace LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs
{
    public class UpdateBookDTO
    {
        public string Title { get; set; } = string.Empty;

        public List<int> AuthorIds { get; set; } = [];  

    }
}
