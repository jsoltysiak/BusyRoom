using System;

namespace BusyRoom.ViewModels
{
    public class StateViewModel
    {
        public bool IsOccupied { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}