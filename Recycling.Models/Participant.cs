using System;

namespace Recycling.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public DateTime ParticipateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}