namespace LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs
{
    /// <summary>
    /// Fields required for new, Title and CoAuthors
    /// </summary>
    public class AuthorMinimalBookDTO
    {
        public required string Title { get; set; }
        public int CoAuthors { get; set; }
    }
}
