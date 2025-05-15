using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class AuthorDTOExtensions
    {

        public static AuthorDTO ToAuthorDTO(this Author author) => new AuthorDTO
        {
            FirstName = author.FirstName,
            LastName = author.LastName
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
