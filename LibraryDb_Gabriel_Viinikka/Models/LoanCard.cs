namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class LoanCard
    {
        public int Id { get; set; }
        public Loaner? LoanerReference { get; set; }
        public int LoanerId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public required DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

    }
}
