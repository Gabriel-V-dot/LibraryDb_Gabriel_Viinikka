namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class BookDTO
    {
        public int Id { get; set; }

        public required string BookTitle { get; set; }

        public required long ISBN { get; set; }

        public required int PublicationYear { get; set; }

        public required Author BookAuthor { get; set; }

    }

    public class CreateBookDTO
    {
        public required string BookTitle { get; set; }
        public required long ISBN { get; set; }
        public required int PublicationYear { get; set; }
        public required Author BookAuthor { get; set; }

    }

    public static class DTOBookExtensions
    {

        public static Book ToBook(this CreateBookDTO createBookDTO)
        {
            return new Book
            { 
                BookTitle = createBookDTO.BookTitle,
                ISBN = createBookDTO.ISBN,
                PublicationDate = new DateOnly(createBookDTO.PublicationYear,1,1),
                Authors = new List<Author> { createBookDTO.BookAuthor}
            };


        }






    }


}
