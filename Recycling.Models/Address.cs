namespace Recycling.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string ReciverName { get; set; }
        public string ReciverTel { get; set; }
        public bool Enabled { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Detail { get; set; }
    }
}