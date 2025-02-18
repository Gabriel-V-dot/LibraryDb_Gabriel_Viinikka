namespace LibraryDb_Gabriel_Viinikka.Models
{
    public static class DTOExtensions
    {

        public static AuthorDTO ToAuthorDTO(this Author author)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                AuthorFirstName = author.FirstName,
                AuthorLastName = author.LastName
            };

        }

        public static Author ToAuthor(this CreateAuthorDTO authorDTO)
        {
            return new Author
            {
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName
            };
        }

        public static Author ToAuthor(this AuthorDTO authorDTO)
        {
            return new Author
            {   
                Id = authorDTO.Id,
                FirstName = authorDTO.AuthorFirstName,
                LastName = authorDTO.AuthorLastName
            };

        }

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

        public static Book ToBook(this CreateBookDTO createBookDTO)
        {
            return new Book
            {
                BookTitle = createBookDTO.BookTitle,
                ISBN = createBookDTO.ISBN,
                PublicationDate = new DateOnly(createBookDTO.PublicationYear, 1, 1),
                Authors = new List<Author> { }
            };
        }

        public static Book ToBook(this BookDTO bookDTO)
        {
            return new Book
            {
                Id = bookDTO.Id,
                BookTitle = bookDTO.BookTitle,
                ISBN = bookDTO.ISBN,
                PublicationDate = new DateOnly(bookDTO.PublicationYear, 1, 1),
                Authors = bookDTO.BookAuthors
            };
        }








    }

}
