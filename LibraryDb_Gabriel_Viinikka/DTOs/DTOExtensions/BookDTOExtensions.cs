using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;
using LibraryDb_Gabriel_Viinikka.Models;
using LibraryDb_Gabriel_Viinikka.DTOs.AuthorDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class BookDTOExtensions
    {
        public static BookDTO ToBookDTO(this Book book, List<MinimalAuthorDTO> authorDtos, List<Rating> ratings)
        {

            return new BookDTO
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationDate,
                AverageRatings = (int)ratings.Average(rate => rate.Score),
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

        public static BookDTO ToBookDTO(this Book book)
        {
            if (book.Ratings.Count < 1)
            {
                return new BookDTO 
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    PublicationYear = book.PublicationDate,
                    BookAuthors = book.Authors
                            .Select(a => a.ToMinimalAuthorDTO())
                            .ToList(),
                    AverageRatings = 0,
                    InventoryCount = book.Inventories
                            .Count()
                };
            }
            else
            {
                return new BookDTO
                {
                    Title = book.Title,
                    ISBN = book.ISBN,
                    PublicationYear = book.PublicationDate,
                    BookAuthors = book.Authors
                            .Select(a => a.ToMinimalAuthorDTO())
                            .ToList(),
                    AverageRatings = book.Ratings
                            .Select(rate => rate.Score)
                            .ToList()
                            .Average(),
                    InventoryCount = book.Inventories
                            .Count()
                };
            }
        }


    }

}
