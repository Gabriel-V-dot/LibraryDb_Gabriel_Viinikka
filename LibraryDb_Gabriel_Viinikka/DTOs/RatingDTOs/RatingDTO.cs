using LibraryDb_Gabriel_Viinikka.Models;
using Microsoft.Identity.Client;

namespace LibraryDb_Gabriel_Viinikka.DTOs.RatingDTOs
{
    public class RatingDTO
    {
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}

