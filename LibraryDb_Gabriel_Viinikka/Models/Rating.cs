namespace LibraryDb_Gabriel_Viinikka.Models
{
    /// <summary>
    /// Fields requried for new: Score, Book and BookId
    /// Optional fields : Comment (string)
    /// </summary>
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public required Book Book { get; set; }
        public required int BookId { get; set; }


    }
}
