﻿using System.ComponentModel.DataAnnotations;

namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class Loaner()
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public ICollection<LoanCard> LoanCards { get; set; } = [];
  

    }

}
