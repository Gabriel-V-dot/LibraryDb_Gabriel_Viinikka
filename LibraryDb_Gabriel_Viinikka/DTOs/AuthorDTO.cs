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
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }

}
