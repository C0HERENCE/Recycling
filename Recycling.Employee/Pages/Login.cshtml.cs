using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recycling.Models;

namespace Recycling.Employee.Pages
{
    public class Login : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public Login(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [TempData]
        public string ErrorMessage { get; set; }
        
        [BindProperty]
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名是必填的")]
        public string Username { get; set; }
        
        
        [BindProperty] 
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码是必填的")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
        }
        
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var result = await _signInManager.PasswordSignInAsync(Username, Password, false, false);
            if (result.Succeeded)
            {
                return LocalRedirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "登录失败");
                return Page();
            }
        }
    }
}