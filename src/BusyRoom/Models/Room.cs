using System.Collections.Generic;

namespace BusyRoom.Models
{
    public class Room
    {
        public Room()
        {
            OccupyStates = new HashSet<OccupyState>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OccupyState> OccupyStates { get; set; }
    }
}