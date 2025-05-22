using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Book()
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public required string ISBN { get; set; }

        public required DateOnly PublicationDate { get; set; }
        public required ICollection<Author> Authors { get; set; }

        public ICollection<Rating> Ratings { get; set; } = [];
        public ICollection<Inventory> Inventories { get; set; } = [];


        //Suggestion from Benjamin to simplify, due to out of time 
        //public int CopiesTotal { get; set; }
        //public int LoanedTotal { get; set; }
    }

}
