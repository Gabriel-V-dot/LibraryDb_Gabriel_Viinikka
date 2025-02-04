namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class BookDTO
    {
        public int Id { get; set; }

        public required string BookTitle { get; set; }

        public required long ISBN { get; set; }

        public required int PublicationYear { get; set; }

        public List<Author>? BookAuthors { get; set; } = new();

    }

    public class CreateBookDTO
    {
        public required string BookTitle { get; set; }
        public required long ISBN { get; set; }
        public required int PublicationYear { get; set; }
        public required int BookAuthorId { get; set; }

    }

    public static class DTOBookExtensions
    {

        public static BookDTO ToBookDTO(this Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                BookTitle = book.BookTitle,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationDate.Year,
                BookAuthors = book.Authors
            };

        }

        public static Book ToBook(this CreateBookDTO createBookDTO, Author createBookAuthor)
        {
            return new Book
            { 
                BookTitle = createBookDTO.BookTitle,
                ISBN = createBookDTO.ISBN,
                PublicationDate = new DateOnly(createBookDTO.PublicationYear,1,1),
                Authors = new List<Author> { createBookAuthor}
            };
        }

        public static Book ToBook(this BookDTO bookDTO)
        {
            return new Book
            {
                Id = bookDTO.Id,
                BookTitle = bookDTO.BookTitle,
                ISBN = bookDTO.ISBN,
                PublicationDate = new DateOnly(bookDTO.PublicationYear,1,1),
                Authors = bookDTO.BookAuthors
            };
        }







    }


}
