namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class BookInventory()
    {
        public int Id { get; set; }
        public required bool IsAvailable { get; set; }
        public required Book Book { get; set; }
    }

}
