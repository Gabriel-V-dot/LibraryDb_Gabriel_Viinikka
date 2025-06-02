using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;
using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class AuthorDTOExtensions
    {

        public static MinimalAuthorDTO ToMinimalAuthorDTO(this Author author) => new MinimalAuthorDTO
        { 
            FirstName = author.FirstName,
            LastName = author.LastName
        };

        public static AuthorDTO ToAuthorDTO(this Author author) => new AuthorDTO
        { 
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Books = author.Books.Select(book => book.ToAuthorMinimalBookDTO()).ToList()
        };

        public static Author ToAuthor(this CreateAuthorDTO authorDTO, List<Book> books)
        {
            return new Author
            {
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName,
                Books = books
            };
        }

    }

}
