﻿namespace LibraryDb_Gabriel_Viinikka.Models
{
    public static class DTOExtensions
    {

        public static AuthorDTO ToAuthorDTO(this Author author)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                AuthorFirstName = author.AuthorFirstName,
                AuthorLastName = author.AuthorLastName
            };

        }

        public static Author ToAuthor(this CreateAuthorDTO authorDTO)
        {
            return new Author
            {
                AuthorFirstName = authorDTO.AuthorFirstName,
                AuthorLastName = authorDTO.AuthorLastName
            };
        }

        public static Author ToAuthor(this AuthorDTO authorDTO)
        {
            return new Author
            {   
                Id = authorDTO.Id,
                AuthorFirstName = authorDTO.AuthorFirstName,
                AuthorLastName = authorDTO.AuthorLastName
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
