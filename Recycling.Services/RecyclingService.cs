namespace Recycling.Services
{
    public class RecyclingService
    {
        public RecyclingService(UserService userService, CategoryService categoryService, OrderService orderService, AddressService addressService, NewsService newsService)
        {
            UserService = userService;
            CategoryService = categoryService;
            OrderService = orderService;
            AddressService = addressService;
            NewsService = newsService;
        }

        public UserService UserService { get; set; }
        public CategoryService CategoryService { get; set; }
        public OrderService OrderService { get; set; }
        public AddressService AddressService { get; set; }
        public NewsService NewsService { get; set; }
    }
}