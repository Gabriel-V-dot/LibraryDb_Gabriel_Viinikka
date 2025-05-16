namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Loans()
    {
        public int Id { get; set; }
        public required DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public required Inventory InventoryBook { get; set; }
        public required int LoanCardId { get; set; }
        public required LoanCard LoanCardReference { get; set; }

    }

}
