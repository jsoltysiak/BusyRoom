using System;
using System.ComponentModel.DataAnnotations;

namespace BusyRoom.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        [RegularExpression(@"\b[a-zA-Z][a-zA-Z0-9_]*\b",
            ErrorMessage = "{0} must be a single word and start with a letter.")]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}