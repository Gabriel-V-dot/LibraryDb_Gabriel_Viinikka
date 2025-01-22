﻿namespace LibraryDb_Gabriel_Viinikka.Models
{
    public class BookDTO
    {
        public int Id { get; set; }

        public required string BookTitle { get; set; }

        public required long ISBN { get; set; }

        public required int PublicationYear { get; set; }

    }

}
