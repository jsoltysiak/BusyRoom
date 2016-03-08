using System;

namespace BusyRoom.Models
{
    public class State
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsOccupied { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}