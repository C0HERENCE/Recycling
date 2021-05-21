using System;

namespace Recycling.Models
{
    public class ProductRecord
    {
        public int Id { get; set; }
        
        public User User { get; set; }
        
        public int UserId { get; set; }
        
        public Product Product { get; set; }
        
        public int ProductId { get; set; }
        
        public DateTime CreateDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }

        public int AddressId { get; set; }

        public int Status { get; set; }
        
        public string ProcesserName { get; set; }
    }
}