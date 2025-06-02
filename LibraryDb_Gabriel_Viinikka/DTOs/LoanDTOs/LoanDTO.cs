namespace LibraryDb_Gabriel_Viinikka.DTOs.LoansDTOs
{
    public class LoanDTO
    {
        public List<ActiveLoanDTO> ActiveLoanDTOs { get; set; } = new();
        public List<ReturnedLoanDTO> ReturnedLoanDTOs { get; set; } = new ();
    }
}
