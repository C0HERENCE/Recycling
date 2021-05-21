using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Recycling.Models
{
    public class RecycleOrder
    {
        [Comment("期望价格")]
        public int Id { get; set; }
        
        [Comment("期望价格")]
        public double ExpectPrice { get; set; }
        [Comment("下单时间")]
        public DateTime CreateDateTime { get; set; }
        [Comment("预约时间")]
        public DateTime OrderedDateTime { get; set; }
        [Comment("完成时间")]
        public DateTime FinishedDateTime { get; set; }
        [Comment("订单状态")]
        public OrderStatus OrderStatus { get; set; }
        
        [Comment("联系地址")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        [Comment("所有类型和他们的重量")]
        
        public virtual IList<RecycleItem> RecycleItems { get; set; }
        
        [Comment("本单所获得的积分")]

        public int AddedScore { get; set; }

        [Comment("处理人")]
        public string ProcesserName { get; set; }
    }
}