using System;

namespace BusyRoom.Models
{
    public class OccupyState
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsBusy { get; set; }

        public Room Room { get; set; }
    }
}