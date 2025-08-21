namespace LibraryDb_Gabriel_Viinikka.Models
{
    /// <summary>
    /// fields required for new Loan:
    /// LoanDate, Book and LoanCard
    /// </summary>
    public class Loan()
    {
        public int Id { get; set; }
        public required DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public required Inventory Inventory { get; set; }
        public int InventoryId { get; set; }
        public int LoanCardId { get; set; }
        public required LoanCard LoanCard { get; set; }

    }

}
