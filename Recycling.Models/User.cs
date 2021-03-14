using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Recycling.Models
{
    public class User : IdentityUser<int>
    {
        public int Score { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public List<RecycleOrder> Orders { get; set; }
    }
}