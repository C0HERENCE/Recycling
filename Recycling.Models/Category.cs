using System.Collections.Generic;

namespace Recycling.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Price> Prices { get; set; }
    }
}