using System.Collections.Generic;

namespace Recycling.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Enabled { get; set; }
        public string Type { get; set; }
        public List<Participant> Paricipants { get; set; }
    }
}