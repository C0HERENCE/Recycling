using Microsoft.AspNetCore.Identity;

namespace Recycling.Models
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
            
        }

        public Role(string roleName) : base(roleName)
        {
            
        }
    }
}