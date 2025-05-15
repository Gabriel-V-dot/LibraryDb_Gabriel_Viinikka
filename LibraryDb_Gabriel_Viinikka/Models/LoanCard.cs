namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class LoanCard
    {
        public int Id { get; set; }
        public Loaner? LoanerReference { get; set; }
        public int LoanerId { get; set; }
        public required DateTime CreationDate { get; set; } = DateTime.Now;
        public required DateTime ExpirationDate { get; set; } = DateTime.Now.AddYears(5);
        public bool IsActive { get; set; }

    }
}
