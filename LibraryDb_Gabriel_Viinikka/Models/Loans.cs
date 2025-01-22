namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Loans()
    {
        public int Id { get; set; }
        public required DateOnly LoanDate {get;set;}
        public DateOnly? ReturnDate { get; set; }
        public DateOnly? ActualReturnDate { get; set; }
        public required BookInventory ActualBook { get; set; }
        public required Loaner Loaner { get; set; }

    }

}
