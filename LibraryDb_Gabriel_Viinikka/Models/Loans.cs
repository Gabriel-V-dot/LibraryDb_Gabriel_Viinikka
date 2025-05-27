namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Loans()
    {
        public int Id { get; set; }
        public required DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public Inventory? InventoryBook { get; set; }
        public int? InventoryId { get; set; }
        public int? LoanCardId { get; set; }
        public LoanCard? LoanCard { get; set; }

    }

}
