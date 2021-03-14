using Recycling.Models;

namespace Recycling.Models
{
    public class RecycleItem
    {
        public int Id { get; set; }
        public int RecycleOrderId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public double Weight { get; set; }
        public virtual RecycleOrder RecycleOrder { get; set; }
    }
}