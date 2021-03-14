using System;

namespace Recycling.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Enabled { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}