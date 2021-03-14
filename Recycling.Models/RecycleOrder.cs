using System;
using System.Collections.Generic;

namespace Recycling.Models
{
    public class RecycleOrder
    {
        public int Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime OrderedDateTime { get; set; }
        public DateTime FinishedDateTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int AddressId { get; set; }
        
        public virtual IList<RecycleItem> RecycleItems { get; set; }
        public Address Address { get; set; }
    }
}