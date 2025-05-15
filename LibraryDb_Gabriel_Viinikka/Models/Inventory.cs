namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public required Book BookReference { get; set; }
        public bool Available { get; set; } = true;
    }
}
