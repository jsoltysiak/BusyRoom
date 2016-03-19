using System;

namespace BusyRoom.ViewModels
{
    public class StateViewModel
    {
        public bool IsOccupied { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public int? Brightness { get; set; }
    }
}