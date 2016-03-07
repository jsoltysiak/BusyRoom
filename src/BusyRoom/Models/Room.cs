using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusyRoom.Models
{
    public class Room
    {
        public Room()
        {
            States = new HashSet<State>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}