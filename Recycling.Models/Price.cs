using Recycling.Models;

namespace Recycling.Models
{
    public class Price
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double Value { get; set; }
    }
}