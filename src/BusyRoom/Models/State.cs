using System;

namespace BusyRoom.Models
{
    public class State
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsOccupied { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public int? Brightness { get; set; }

        public virtual Room Room { get; set; }
    }
}