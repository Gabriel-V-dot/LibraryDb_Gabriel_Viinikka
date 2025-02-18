namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Book()
    {
        public int Id { get; set; }
        public required string BookTitle { get; set; }

        public required long ISBN { get; set; }

        public required DateOnly PublicationDate { get; set; }
        public List<Author>? Authors { get; set; } = new();

        public int CopiesTotal { get; set; }
        public int LoanedTotal { get; set; }
    }

}
