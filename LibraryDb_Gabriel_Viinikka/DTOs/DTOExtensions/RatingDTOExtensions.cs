using LibraryDb_Gabriel_Viinikka.DTOs.RatingDTOs;
using LibraryDb_Gabriel_Viinikka.Models;

namespace LibraryDb_Gabriel_Viinikka.DTOs.DTOExtensions
{
    public static class RatingDTOExtensions
    {

        public static Rating ToRating(this CreateRatingDTO ratingDTO, Book book)
        {
            return new Rating
            {
                Score = ratingDTO.Score,
                Comment = ratingDTO.Comment,
                Book = book,
                BookId = book.Id
            };
        }

        public static RatingDTO ToRatingDTO(this Rating rating)
        {
            return new RatingDTO
            {
                Score = rating.Score,
                Comment = rating.Comment,
                Book = rating.Book.ToMinimalBookDTO()
            };
        }


    }
}
