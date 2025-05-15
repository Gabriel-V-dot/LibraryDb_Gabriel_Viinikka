using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class BookDTOExtensions
    {
        public static BookDTO ToBookDTO(this Book book, List<AuthorDTO> authorDtos)
        {

            return new BookDTO
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationDate,
                BookAuthors = authorDtos
            };

        }

        public static Book ToBook(this CreateBookDTO createBookDTO, List<Author> authors)
        {
            return new Book
            {
                Title = createBookDTO.Title,
                ISBN = createBookDTO.ISBN,
                PublicationDate = createBookDTO.PublicationYear,
                Authors = authors
            };
        }


    }

}
