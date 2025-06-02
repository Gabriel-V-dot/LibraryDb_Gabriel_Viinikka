using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class BookDTOExtensions
    {

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

        public static BookDTO ToBookDTO(this Book book)
        {
                return new BookDTO 
                {
                    Id = book.Id,
                    Title = book.Title,
                    ISBN = book.ISBN,
                    PublicationYear = book.PublicationDate,
                    BookAuthors = book.Authors
                            .Select(a => a.ToMinimalAuthorDTO())
                            .ToList(),
                    AverageRating = book.Ratings.Any() ? Math.Round(book.Ratings.Average(rate => rate.Score),2) : 0,
                    InventoryCount = book.Inventories
                            .Count()
                };
        }

        public static MinimalBookDTO ToMinimalBookDTO(this Book book)
        {
            return new MinimalBookDTO { 
                Title = book.Title, 
                Authors = book.Authors
                .Select(auth => auth
                .ToMinimalAuthorDTO())
                .ToList()
            };
        }

        public static AuthorMinimalBookDTO ToAuthorMinimalBookDTO(this Book book)
        {
            return new AuthorMinimalBookDTO
            {
                Title = book.Title,
                CoAuthors = book.Authors.Count() <= 1 ? 0 : book.Authors.Count()-1
            };
        }

    }

}
