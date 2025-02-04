namespace LibraryDb_Gabriel_Viinikka.Models
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


    }

}
