namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Loans()
    {
        public int Id { get; set; }
        public required DateOnly LoanedOn {get;set;}
        public DateOnly? ReturnDueOn { get; set; }
        public DateOnly? ReturnedOn { get; set; }
        public required Book Book { get; set; }
        public required Loaner Loaner { get; set; }

    }

}
