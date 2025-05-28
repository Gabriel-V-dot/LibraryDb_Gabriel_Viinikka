namespace LibraryDb_Gabriel_Viinikka.Models
{
    /// <summary>
    /// Navigation properties: Loaner
    /// Fields requried for new: Loaner, CreationDate, ExpirationDate and IsActive
    /// </summary>
    public class LoanCard
    {
        public int Id { get; set; }
        public Loaner? Loaner { get; set; }
        public int? LoanerId { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required DateTime ExpirationDate { get; set; } = DateTime.Now.AddYears(5);
        public bool IsActive { get; set; }

    }
}
