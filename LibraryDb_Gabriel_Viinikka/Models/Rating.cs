namespace LibraryDb_Gabriel_Viinikka.Models
{
    /// <summary>
    /// Fields requried for new: Score and Comment
    /// </summary>
    public class Rating
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public ICollection<Book> Books { get; set; } = [];


    }
}
