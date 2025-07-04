﻿using LibraryDb_Gabriel_Viinikka.DTOs.BookDTOs;

namespace LibraryDb_Gabriel_Viinikka.DTOs.RatingDTOs
{
    public class RatingDTO
    {
        public int Score { get; set; }
        public string? Comment { get; set; }
        public required MinimalBookDTO Book { get; set; }
    }
}

