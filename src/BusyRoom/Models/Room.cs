using System.Collections.Generic;

namespace BusyRoom.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OccupyState> OccupyStates;
    }
}