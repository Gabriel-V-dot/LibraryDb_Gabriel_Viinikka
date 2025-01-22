

namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Author()
    {
        public int Id { get; set; }
        public required string AuthorFirstName { get; set; }
        public required string AuthorLastName { get; set; }
        public List<Book>? Books { get; set; } = new();

    }

}
