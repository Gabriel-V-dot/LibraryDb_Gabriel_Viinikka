namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public required string AuthorFirstName { get; set; }
        public required string AuthorLastName { get; set; }
    }

    public class CreateAuthorDTO
    {
        public required string AuthorFirstName { get; set; }
        public required string AuthorLastName { get; set; }
    }
    public static class DTOAuthorExtensions
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








    }

}
