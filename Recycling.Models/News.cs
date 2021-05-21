using System;
using System.Collections.Generic;

namespace Recycling.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreateTime { get; set; }
        public int AuthorId { get; set; }
        public AdminUser Author { get; set; }
        public List<Reply> Replies { get; set; }
    }
}