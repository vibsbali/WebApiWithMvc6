using System;
using System.Collections.Generic;
using TheWorld.Entities;

namespace TheWorld.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Username { get; set; }

        public ICollection<Stop> Stops { get; set; }
    }
}
